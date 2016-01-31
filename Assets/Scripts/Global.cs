﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Global : MonoBehaviour {

	public string firstScene = "";

//	private static float timeLeft;
	private static int difficulty;
	private static float score = 100.0f;
	private static float timeCount = 0.0f;
	private static string lastSceneName = "";
	private static float nextLoadBad = 0;
	private static bool loadLevel = false;
	public static bool loadBadLevel = false;

//	public static void ResetTimer(float duration = 10.0f) {
//		timeLeft = duration;
//	}


	public static void AddPoints(float points) {
		score = Mathf.Min (score + points, Mathf.Ceil(score/20)*20-1);

		score += points;
		Debug.Log ("lol2");
	}

	public static void SubtractPoints(float points) {
		Debug.Log ("lol");
		Debug.Log (Mathf.Ceil ((score - points) / 20) != Mathf.Ceil (score / 20) && Time.time > nextLoadBad);
		Debug.Log ("sup");
		if (Mathf.Ceil ((score - points) / 20) != Mathf.Ceil (score / 20) && Time.time > nextLoadBad) {
			Debug.Log ("hehz");

			loadBadLevel = true;
			nextLoadBad = Time.time + 1.5f;

			score -= points;
			Debug.Log ("test");
//			Animator animator = GameObject.Find ("Canvas/Emotion").GetComponent<Animator> ();
//			animator.SetTrigger ("Pop");
			LoadBadLevel ();
			Debug.Log ("test2");
		} else {
			score -= points;
		}
	}

	public static float GetScore() {
		Debug.Log ("lulz");
		return score;
	}

	public static int GetDifficulty() {
		Debug.Log ("yup");
		return difficulty;
	}

	public static void LoadBadLevel() {
		Debug.Log ("hahaha");
		if (lastSceneName == "Bathroom") {
			Debug.Log ("mmm");
			LoadLevel ("Party");
		} else if (lastSceneName == "Party") {
			Debug.Log ("mmm2");
			LoadLevel ("Handshake");
		}
	}

	public static void LoadNextLevel() {
		
	}

	public static void LoadLevel(string sceneName) {
		Debug.Log ("zzz");
		if (lastSceneName != "") {
			Debug.Log ("unloading scene" + lastSceneName);
			SceneManager.UnloadScene(lastSceneName);
		}
		Debug.Log ("aaa");
		lastSceneName = sceneName;
		loadLevel = true;
		difficulty += 1;
	}

	// Use this for initialization
	void Start () {
		LoadLevel (firstScene);
	}
	
	// Update is called once per frame
	void Update () {
		if (loadLevel) {
			Debug.Log ("kek");
			loadLevel = false;
			SceneManager.LoadSceneAsync (lastSceneName, LoadSceneMode.Additive);
			Debug.Log ("kik");
			loadBadLevel = false;
		}

		timeCount += Time.deltaTime;
		GameObject.Find ("Canvas/Time").GetComponent<Text>().text = "" + timeCount;
		GameObject.Find ("Canvas/Score").GetComponent<Text>().text = "" + score;
		GameObject.Find ("Canvas/Emotion").GetComponent<Animator>().SetInteger("Frame", (int)(5-Mathf.Ceil(score/100.0f*5.0f)));
//		Debug.Log (Mathf.Floor(score/100.0f*5));
//		timeLeft -= Time.deltaTime;
//		if (timeLeft < 0) {
//			//
//		}
	}
}
