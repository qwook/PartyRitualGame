using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GUI.FocusControl ("Play");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySelected() {
		
		SceneManager.LoadScene ("GlobalGame", LoadSceneMode.Single);
	}

	public void LeaderBoardSelected() {

	}

	public void CreditsSelected() {

	}

	public void TitleSelected() {

	}
}
