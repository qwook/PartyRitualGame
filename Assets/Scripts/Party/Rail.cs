using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Rail : MonoBehaviour {

	public GameObject[] rounds;


//	public int groupDistanceFromCamera = 22;
//	public int numRounds = 3;

//	private int round = 0;
//	private string choice;
	private Round currentRound;

	private Animator animator;

//	private bool ended = false;
//	private bool checking = false;

	private bool failedCheck = false;

	public string lastSide;

	public float cameraAngle = 0.0f;

	// Use this for initialization
	void Start () {
//		currentRound = rounds [round++].GetComponent<Round> ();
		animator = GetComponent<Animator>();
		float speedUp = (Global.GetDifficulty () / 16) ;
		animator.speed = 1f + speedUp;

//		animator.speed = 10;	
	}

	

	// Update is called once per frame
	void Update () {
		float input = Input.GetAxis ("Horizontal");

		float goalYaw = 0.0f;

		if (failedCheck) {
			if (lastSide == "right") {
				goalYaw = 15.7777f;
			} else if (lastSide == "left") {
				goalYaw = -15.7777f;
			}
		} else {
			if (input > 0.2f) {
				goalYaw = 15.7777f;
			} else if (input < -0.2f) {
				goalYaw = -15.7777f;
			}
		}
//		currentRound.select (choice);

		cameraAngle += (goalYaw - cameraAngle) * 0.15f;
		Quaternion angles = transform.localRotation;
		Vector3 eulerAngle = angles.eulerAngles;
		eulerAngle.y = cameraAngle;
		angles.eulerAngles = eulerAngle;
		transform.localRotation = angles;

//		if (ended) {
//			ended = false;
//			Global.LoadLevel ("PartyRail");
//			Global.LoadLevel ("Handshake");
//		}

//		if (checking) {
//			check ();
//		}

	}

	public void check() {
		float input = Input.GetAxis ("Horizontal");

		if (input > 0.1f) {
			if (lastSide == "right") {
				Global.SubtractPoints (5);
				failedCheck = true;
				currentRound.fail (lastSide);
			} else {
				Global.AddPoints (5f);
				currentRound.cool ("right");
			}
		} else if (input < -0.1f) {
			if (lastSide == "left") {
				Global.SubtractPoints (5);
				failedCheck = true;
				currentRound.fail (lastSide);
			} else {
				Global.AddPoints (5f);
				currentRound.cool ("left");
			}
		} else {
			Global.SubtractPoints (10);
			failedCheck = true;
			currentRound.fail (lastSide);
		}

//		bool success = currentRound.check (choice);
//
//		if (success == true) {
//			Global.AddPoints (5f);
//		} else {
//			if (choice == "none")
//				Global.SubtractPoints (10);
//			else {
//				Global.SubtractPoints (5);
//				ended = true;
//				Global.LoadLevel ("Handshake");
//			}
//
//		}
			
	}

	public void startCheck() {
//		checking = true;
	}

	public void endCheck() {
//		currentRound = rounds [round++].GetComponent<Round> ();
//		checking = false;
		if (failedCheck) {
			Global.LoadLevel ("Handshake");
		}

	}

	public void activate(int round) {
		lastSide = Random.Range (0, 2) == 1 ? "right" : "left";
		currentRound = rounds [round].GetComponent<Round> ();
		currentRound.activate (lastSide);
//		currentRound.activate ();
	}

	public void end() {
		Global.LoadLevel ("Table");
//		ended = true;
//		Debug.Log ("end");
	}
	
}
