using UnityEngine;
using System.Collections;

public class MyFist : MonoBehaviour {

	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) {
			this.GetComponent<SpriteRenderer> ().sprite = sprites [1];
		} else if (Input.GetButton ("Fire2")) {
			this.GetComponent<SpriteRenderer> ().sprite = sprites [2];
		} else {
			this.GetComponent<SpriteRenderer> ().sprite = sprites [0];
		}
	}
}
