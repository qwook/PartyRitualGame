using UnityEngine;
using System.Collections;

public class Partier : MonoBehaviour {

	Animator animator;
	public float facePlayerTime = 2.0f;
	public float faceAwayTime = 5.0f;

	public bool facing;

	private lastTurnTime;



	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		lastTurn = Time.time;
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
