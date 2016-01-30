using UnityEngine;
using System.Collections;

public class Partier : MonoBehaviour {

	Animator animator;
	public float facePlayerTime = 2.0f; //The time (in secs) Partier faces the screen.
	public float faceAwayTime = 5.0f; //The time (in secs) Partier faces away from the screen.

	public bool facing = false;

	private float lastTurnTime;



	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		lastTurnTime = Time.time;

		//set next faceAwayTime to a random val
		faceAwayTime = Random.Range(2,6);

		//set next facePlayerTime to a random val
		facePlayerTime = Random.Range(0.5f,4);

	}
	
	// Update is called once per frame
	void Update () {
		float timePassed = Time.time - lastTurnTime;

		if (!facing) {
			if (timePassed > faceAwayTime) {
				animator.SetTrigger("FacePlayer");
				facing = true;
				lastTurnTime = Time.time;
			}
		} else {
			if (timePassed > facePlayerTime) {
				animator.SetTrigger("UnFacePlayer");
				facing = false;
				lastTurnTime = Time.time;

			}
		}
	}

	
}
