using UnityEngine;
using System.Collections;

public class Round : MonoBehaviour {

	public string side;

	public GameObject leftGroup;
	public GameObject rightGroup;

	private PartyGroup partyGroup;


	// Use this for initialization
	void Start () {
//		side = Random.Range (0, 2) == 1 ? "right" : "left";
//		if (side == "right") {
//			partyGroup = rightGroup.GetComponent<PartyGroup> ();
//		} else {
//			partyGroup = leftGroup.GetComponent<PartyGroup> ();
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void select(string direction) {
//		if (direction == "right") {
//			rightGroup.GetComponent<PartyGroup> ().highlight(Color.cyan);
//			leftGroup.GetComponent<PartyGroup> ().highlight(Color.white);
//		} else if (direction == "left") {
//			leftGroup.GetComponent<PartyGroup> ().highlight(Color.cyan);
//			rightGroup.GetComponent<PartyGroup> ().highlight(Color.white);
//		} else {
//
//			leftGroup.GetComponent<PartyGroup> ().highlight(Color.white);
//			rightGroup.GetComponent<PartyGroup> ().highlight(Color.white);
//		}
	}

	public void hightlight(string direction, Color c) {
//		if (direction == "right") {
//			rightGroup.GetComponent<PartyGroup> ().highlight (c);
//		} else if (direction == "left") {
//			leftGroup.GetComponent<PartyGroup> ().highlight(c);
//		} else {
//			leftGroup.GetComponent<PartyGroup> ().highlight(c);
//			rightGroup.GetComponent<PartyGroup> ().highlight (c);
//		}
	}

//	public bool check(string s) {
//		Debug.Log (s + " = " + side); 
//		if (s != side && s != "none") {
//			hightlight (s, Color.green);
//			return true;
//		} else {
//			hightlight (s, Color.red);
//			return false;
//		}
//	}

	public void cool(string side) {
		if (side == "left") {
			leftGroup.transform.FindChild ("Emoji").gameObject.GetComponent<Animator> ().SetTrigger ("OhYes");
		} else if (side == "right") {
			rightGroup.transform.FindChild ("Emoji").gameObject.GetComponent<Animator> ().SetTrigger ("OhYes");
		}
	}

	public void fail(string side) {
		if (side == "left") {
			leftGroup.transform.FindChild ("Emoji").gameObject.GetComponent<Animator> ().SetTrigger ("OhNo");
		} else if (side == "right") {
			rightGroup.transform.FindChild ("Emoji").gameObject.GetComponent<Animator> ().SetTrigger ("OhNo");
		}
	}

	public void activate(string side) {
		if (side == "left") {
			leftGroup.GetComponent<PartyGroup> ().Rotate ();
		} else if (side == "right") {
			rightGroup.GetComponent<PartyGroup> ().Rotate ();
		}
//		Debug.Log ("activate");
//		partyGroup.Rotate ();
	}
		
}
