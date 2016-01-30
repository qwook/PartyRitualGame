using UnityEngine;
using System.Collections;

public class Partier : MonoBehaviour {

	Animator animator;
	public float facePlayerTime = 2.0f;
	public float faceAwayTime = 5.0f;

	public bool facing;

	private float lastTurnTime;



	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		lastTurnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {


		if (!facing) {

		}


		bool fire = Input.GetButtonDown("Fire1");
		if (fire == true) {
			animator.SetTrigger("FacePlayer");
			Debug.Log ("hello");
		}
	
	}
}
