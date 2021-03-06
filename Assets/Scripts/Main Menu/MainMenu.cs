﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public float showLeaderBoardDelay = 0.5f;
	public float hideLeaderBoardDelay = 0.5f;
	public bool showLeaderboard = false;

//	public AudioClip mainMenuSong;

	public AudioClip[] navSounds;
	private AudioSource source;

	void Awake () {

		source = GetComponent<AudioSource>();

	}

	// Use this for initialization
	void Start () {
		GUI.FocusControl ("Play");
//		source.Play (mainMenuSong);
	}
	
	// Update is called once per frame
	void Update () {
		if (showLeaderboard && showLeaderBoardDelay > 0) {
			showLeaderBoardDelay -= Time.deltaTime;
		}

		if (hideLeaderBoardDelay > 0) {
			hideLeaderBoardDelay -= Time.deltaTime;
		}
	}

	public void OnGUI() {
		if (Event.current.type == EventType.KeyDown) {

			if(navSounds.Length > 0) 
				source.PlayOneShot (navSounds[Random.Range(0,navSounds.Length)]);

			if (showLeaderboard && showLeaderBoardDelay <= 0) {
				GUI.enabled = true;
				showLeaderboard = false;
				GameObject.Find ("CreditsScreen").GetComponent<Animator> ().SetBool ("Showing", false);
				hideLeaderBoardDelay = 0.5f;
			}
		}
	}

	public void PlaySelected() {
		
		SceneManager.LoadScene ("Intro1", LoadSceneMode.Single);
	}

	public void LeaderBoardSelected() {
	}

	public void CreditsSelected() {
		if (!showLeaderboard && hideLeaderBoardDelay <= 0) {
//			Debug.Log ("yup!");
			GUI.enabled = false;
			showLeaderboard = true;
			showLeaderBoardDelay = 0.5f;
			GameObject.Find ("CreditsScreen").GetComponent<Animator>().SetBool("Showing", true);
		}
	}

	public void TitleSelected() {

	}
}
