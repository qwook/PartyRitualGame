using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Global : MonoBehaviour {

//	private static float timeLeft;
	private static int difficulty;
	private static float score = 100.0f;
	private static float timeCount = 0.0f;
	private static string lastSceneName = "";

//	public static void ResetTimer(float duration = 10.0f) {
//		timeLeft = duration;
//	}


	public static void AddPoints(float points) {
		score = Mathf.Min (score + points, Mathf.Ceil(score/20)*20-1);
		Debug.Log (Mathf.Ceil(score/20)*20);
		score += points;
	}

	public static void SubtractPoints(float points) {
		score -= points;
	}

	public static float GetScore() {
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
		GameObject.Find ("Canvas/Score").GetComponent<Text>().text = "" + score;
		GameObject.Find ("Canvas/Emotion").GetComponent<Animator>().SetInteger("Frame", (int)(4-Mathf.Floor(score/100.0f*5.0f)));
//		Debug.Log (Mathf.Floor(score/100.0f*5));
//		timeLeft -= Time.deltaTime;
//		if (timeLeft < 0) {
//			//
//		}
	}
}
