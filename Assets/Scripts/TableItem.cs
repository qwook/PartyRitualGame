using UnityEngine;
using System.Collections;

public class TableItem : MonoBehaviour {

	private bool selected = false;
	private bool gucci = true;

	GameObject goal;

	public bool isGucci() {
		return gucci;
	}

	public bool isSelected() {
		return selected;
	}

	public void Select() {
		selected = true;
		Debug.Log ("selected");
		GameObject highlight = transform.FindChild ("Highlight").gameObject;
		goal = Instantiate (highlight);
		goal.SetActive (true);
		goal.transform.position = new Vector3 (
			Random.Range(-2.080754f, 1.745751f),
			0.3f,
			Random.Range(-2.044007f, -0.02f)
		);
		goal.transform.localRotation = transform.localRotation;
		goal.transform.localScale = transform.localScale;
		goal.GetComponent<Renderer> ().material.color = new Color (0.8f, 0.7f, 0.7f, 0.75f);

		highlight.SetActive (true);
	}

	public void Unselect() {
		gucci = false;
		selected = false;
		Debug.Log ("unselect");
		GameObject highlight = transform.FindChild ("Highlight").gameObject;
		highlight.SetActive (false);
		GameObject.Destroy (goal);
	}

	// Use this for initialization
	void Start () {

	}

	public float Distance() {
		return (goal.transform.position - transform.position).magnitude;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject highlight = transform.FindChild ("Highlight").gameObject;

		Vector3 position = transform.localPosition;
		if (selected) {
			if (Input.GetAxis ("Horizontal") > 0) {
				position.x -= Time.deltaTime * 5.0f;
			}

			if (Input.GetAxis ("Horizontal") < 0) {
				position.x += Time.deltaTime * 5.0f;
			}

			if (Input.GetAxis ("Vertical") > 0) {
				position.z -= Time.deltaTime * 5.0f;
			}

			if (Input.GetAxis ("Vertical") < 0) {
				position.z += Time.deltaTime * 5.0f;
			}
		}

		position.z = Mathf.Clamp (position.z, -2.044007f, -0.02f);
		position.x = Mathf.Clamp (position.x, -2.080754f, 1.745751f);

		transform.localPosition = position;

		if (selected) {
			highlight.GetComponent<Renderer> ().material.color = new Color (1f, 1f, 1f, (Mathf.Sin (Time.time * 5) + 1) / 4f);
		}

		if (goal && (goal.transform.position - transform.position).magnitude < 0.35) {

			Global.AddPoints (10);

			Unselect ();
			(GameObject.Find("Items").GetComponent<TableHandler>()).SelectNew();
		}
	}
}
