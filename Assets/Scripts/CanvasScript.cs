using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {

	public bool loaded = false;

	public void Lose() {
		loaded = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (loaded == true) {
			Global.LoadLevel ("Loser");
			loaded = false;
		}
	}
}
