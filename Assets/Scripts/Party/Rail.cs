using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Rail : MonoBehaviour {

	public GameObject[] rounds;


	public int groupDistanceFromCamera = 22;
	public int numRounds = 3;

	private int round = 0;
	private string choice;
	private Round currentRound;

	// Use this for initialization
	void Start () {
		currentRound = rounds [round++].GetComponent<Round> ();
	}

	

	// Update is called once per frame
	void Update () {
		float input = Input.GetAxis ("Horizontal");

		if (input > 0.2f) {
			choice = "right";
		} else if (input < -0.2f) {
			choice = "left";
		} else {
			choice = "none";
		}
		currentRound.select (choice);

	}

	public void check() {
		Debug.Log ("Check");
		Debug.Log ("choice " + choice);
		bool success = currentRound.check (choice);

		if (success == true) {
			Global.AddPoints (5f);
		} else {
			if (choice == "none")
				Global.SubtractPoints (10);
			else
				Global.SubtractPoints (5);
		}

		currentRound = rounds [round++].GetComponent<Round> ();
	}

	public void activate() {
		currentRound.activate ();
	}

	public void end() {
		Debug.Log ("end");
		SceneManager.LoadScene ("Handshake", LoadSceneMode.Single);
	}
	
}
