using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class InputChange : MonoBehaviour {
	Text datext;
	char[] abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*{}".ToCharArray();
	int location = 0;

	bool canUpdate = false;

	float nextUpdate;

	// Use this for initialization
	void Start () {
		datext = transform.FindChild ("Text").GetComponent<Text> ();
		Debug.Log (abc[location]);
		setText (abc[location]);

		nextUpdate = Time.fixedTime;


	}

	void OnGUI() { 
		
		if (EventSystem.current.currentSelectedGameObject.name == this.name) {
			canUpdate = true;

		} else {
			canUpdate = false;
		}

	}

	// Update is called once per frame
	void Update () {
		
		if (canUpdate) {
			float axis = Input.GetAxis ("Vertical");
			if (Time.fixedTime > nextUpdate) {
				if (axis == -1) {
					changeText ("down");
					nextUpdate = Time.fixedTime + .05f;

				} else if (axis == 1) {
					changeText ("up");
					nextUpdate = Time.fixedTime + .05f;
				}
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				changeText ("down");
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				changeText ("up");
			}
		}



	}

	void changeText(string direction) {
		if (direction == "down") {
			location++;
			if (location >= abc.Length)
				location = 0;
			setText (abc [location]);
		} else if (direction == "up") {
			location--;
			if (location < 0)
				location = abc.Length -1;
			setText (abc [location]);
		}
	}

	void setText(char c) {
		
		datext.text = c.ToString();

	}


	

}
