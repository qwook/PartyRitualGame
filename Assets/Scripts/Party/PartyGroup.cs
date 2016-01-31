using UnityEngine;
using System.Collections;

public class PartyGroup : MonoBehaviour {

	public GameObject[] partiers;

	public bool isFacing = false;

	// Use this for initialization
	void Start () {
		

	}

	// Update is called once per frame
	void Update () {
		Rotate ();
	}

	public void Rotate() {
		foreach (Transform child in transform) {
			child.GetComponent<Animator> ().SetTrigger ("FacePlayer");
			child.GetComponent<Animator> ().speed = 2;
		}
	}

	public void highlight(Color c) {
		foreach (Transform child in transform) {
			child.GetComponent<SpriteRenderer> ().color = c;
		}
	}

	public void Facing(bool f) {
		isFacing = true;
	}



}
