using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Global : MonoBehaviour {

//	private static float timeLeft;
	private static int difficulty;
	private static float score;
	private static float timeCount = 0.0f;
	private static string lastSceneName = "";

//	public static void ResetTimer(float duration = 10.0f) {
//		timeLeft = duration;
//	}


	public static void AddPoints(float points) {
		score += points;
	}

	public static void SubtractPoints(float points) {
		score += points;
	}

	public static int GetScore() {
		return score;
	}

	public static int GetDifficulty() {
		return difficulty;
	}

	public static void LoadNextLevel() {
		
	}

	public static void LoadLevel(string sceneName) {
		if (lastSceneName != "") {
			SceneManager.UnloadScene(lastSceneName);
		}
		SceneManager.LoadScene (sceneName, LoadSceneMode.Additive);
		lastSceneName = sceneName;

		difficulty += 1;
	}

	// Use this for initialization
	void Start () {
		LoadLevel ("Bathroom");
	}
	
	// Update is called once per frame
	void Update () {
		timeCount += Time.deltaTime;
		GameObject.Find ("Canvas/Time").GetComponent<Text>().text = "" + timeCount;
//		timeLeft -= Time.deltaTime;
//		if (timeLeft < 0) {
//			//
//		}
	}
}
