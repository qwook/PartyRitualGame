using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	public string button;
	Vector3 home;

	private float dirtiness = 100;

	// Use this for initialization
	void Start () {
		home = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		GameObject dirty = this.transform.FindChild ("DirtyHand").gameObject;
		dirty.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, dirtiness/100f);

		GameObject goal = GameObject.Find ("Goal");
		if (Input.GetButton (button)) {
			this.transform.position = Vector3.Lerp(this.transform.position, goal.transform.position, 0.2f);
		} else {
			this.transform.position = Vector3.Lerp(this.transform.position, home, 0.2f);
		}
	}

	void OnTriggerEnter(Collider other) {
//		Debug.Log (other);
	}

	void OnTriggerExit(Collider other) {
//		Debug.Log (other);
	}

	void OnTriggerStay(Collider other) {
		if (other.CompareTag("CleanWater")) {
			dirtiness = Mathf.Max(dirtiness - Time.deltaTime*50f, 0f);
		}
			
		if (other.CompareTag("DirtyWater")) {
			dirtiness = Mathf.Min(dirtiness + Time.deltaTime*50f, 100f);
		}

		Debug.Log (dirtiness);
	}

}
