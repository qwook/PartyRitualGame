using UnityEngine;
using System.Collections;

public class Partier : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		bool fire = Input.GetButtonDown("Fire1");
		if (fire == true) {
			animator.SetTrigger("FacePlayer");
			Debug.Log ("hello");
		}
	
	}
}
