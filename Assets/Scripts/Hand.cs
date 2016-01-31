using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	public int cleanWaters = 0;
	public int dirtyWaters = 0;

	public string button;
	Vector3 home;

	private float dirtiness = 100;

	// Use this for initialization
	void Start () {
		home = this.transform.position;
	}

	public bool IsClean() {
		return dirtiness <= 0;
	}

	// Update is called once per frame
	void Update () {
		if (Global.loadBadLevel)
			return;
		
		GameObject dirty = this.transform.FindChild ("DirtyHand").gameObject;
		dirty.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, dirtiness/100f);

		GameObject goal = GameObject.Find ("Goal");
		if (Input.GetButton (button)) {
			this.transform.position = Vector3.Lerp(this.transform.position, goal.transform.position, 0.2f);
		} else {
			this.transform.position = Vector3.Lerp(this.transform.position, home, 0.2f);
		}

		if (cleanWaters > 0) {
			dirtiness = Mathf.Max(dirtiness - Time.deltaTime*50f, 0f);
			Global.AddPoints (Time.deltaTime*5f);
		} else if (dirtyWaters > 0) {
			dirtiness = Mathf.Min(dirtiness + Time.deltaTime*50f, 100f);
			Global.SubtractPoints (Time.deltaTime*3f);
		}

		Global.SubtractPoints (Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("CleanWater")) {
			cleanWaters++;
		}

		if (other.CompareTag ("DirtyWater")) {
			dirtyWaters++;
		}

//		Debug.Log (other);
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("CleanWater")) {
			cleanWaters--;
		}

		if (other.CompareTag ("DirtyWater")) {
			dirtyWaters--;
		}
	}

	void OnTriggerStay(Collider other) {
//		if (Global.loadBadLevel)
//			return;
//		
//		if (other.CompareTag("CleanWater")) {
//			dirtiness = Mathf.Max(dirtiness - Time.deltaTime*50f, 0f);
//			Global.AddPoints (Time.deltaTime*5f);
//		}
//			
//		if (other.CompareTag("DirtyWater")) {
//			dirtiness = Mathf.Min(dirtiness + Time.deltaTime*50f, 100f);
//			Global.SubtractPoints (Time.deltaTime*3f);
//		}

//		Debug.Log (dirtiness);
	}

}
