using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Global : MonoBehaviour {

	public static Global one;

	public string firstScene = "";

//	private static float timeLeft;
	private static int difficulty;
	private static float score = 100.0f;
	private static float timeCount = 0.0f;
	private static string lastSceneName = "";
	private static float nextLoadBad = 0;
	private static bool loadLevel = false;
	public static bool loadBadLevel = false;
	private static bool lost = false;
	public float lostDelay = 1.0f;

	public GameObject minusPrefab;
	public GameObject plusPrefab;

	public static float nextContinuousDroplet = 0.0f;

	public static float lastScore = 100.0f;

//	public static void ResetTimer(float duration = 10.0f) {
//		timeLeft = duration;
//	}


	public static void AddPoints(float points) {
		score = Mathf.Min(Mathf.Min (score + points, Mathf.Ceil(score/20)*20), 100);
	}

	public static void SubtractPoints(float points) {
		if (Mathf.Ceil ((score - points) / 20) != Mathf.Ceil (score / 20) && Time.time > nextLoadBad) {

			loadBadLevel = true;
			nextLoadBad = Time.time + 1.5f;

			score -= points;
			Animator animator = GameObject.Find ("Canvas/Emotion").GetComponent<Animator> ();
			animator.SetTrigger ("Pop");
			LoadBadLevel ();
		} else {
			score -= points;
		}

		if (score <= 0 && !lost) {
			lost = true;
			GameObject.Find ("Canvas").GetComponent<Animator> ().SetTrigger ("Lose");
		}
	}

	public static float GetScore() {
		return score;
	}

	public static int GetDifficulty() {
		return difficulty;
	}

	public static void LoadBadLevel() {
		if (lastSceneName == "Bathroom") {
			LoadLevel ("PartyRail");
		} else if (lastSceneName == "PartyRail") {
			LoadLevel ("Handshake");
		}
	}

	public static void LoadNextLevel() {
		
	}

	public static void LoadLevel(string sceneName) {
		if (lastSceneName != "") {
			SceneManager.UnloadScene(lastSceneName);
		}
		lastSceneName = sceneName;
		loadLevel = true;
		difficulty += 1;
	}

	// Use this for initialization
	void Start () {
		one = this;

		score = 100.0f;
		timeCount = 0.0f;
		lastSceneName = "";
		nextLoadBad = 0;
		loadLevel = false;
		loadBadLevel = false;
		lost = false;
		lostDelay = 1.0f;

		lastScore = 100.0f;

		LoadLevel (firstScene);
	}
	
	// Update is called once per frame
	void Update () {
		if (loadLevel) {
			loadLevel = false;
			SceneManager.LoadSceneAsync (lastSceneName, LoadSceneMode.Additive);
			loadBadLevel = false;
		}

		if (!lost) {
			timeCount += Time.deltaTime;
		} else {
			lostDelay -= Time.deltaTime;
			if (lostDelay <= 0) {
				if (Input.anyKeyDown) {
					SceneManager.LoadScene ("MainMenu");
				}
			}
		}
		GameObject.Find ("Canvas/Time").GetComponent<Text>().text = "" + Mathf.Floor(timeCount*10)/10 + "s";
//		GameObject.Find ("Canvas/Score").GetComponent<Text>().text = "" + score;
		GameObject.Find ("Canvas/Emotion").GetComponent<Animator>().SetInteger("Frame", (int)(5-Mathf.Ceil(score/100.0f*5.0f)));
//		Debug.Log (Mathf.Floor(score/100.0f*5));
//		timeLeft -= Time.deltaTime;
//		if (timeLeft < 0) {
//			//
//		}

		// droplet stuff


		if (Time.fixedTime > nextContinuousDroplet) {
			nextContinuousDroplet = Time.fixedTime + 0.15f;

			float difference = score - lastScore;

			if (difference < -0.1) {
				GameObject droplet = Instantiate (one.minusPrefab);
				droplet.transform.SetParent (GameObject.Find ("Canvas/EmotionSpawner").transform);
				droplet.transform.localPosition = new Vector3 (0, 0, -1);
				droplet.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);

				if (difference < -5) {
					droplet.transform.localScale = new Vector3 (2.5f, 2.5f, 2.5f);
				} else if (difference < -1) {
					droplet.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				}
			} else if (difference > 0.1) {
				GameObject droplet = Instantiate (one.plusPrefab);
				droplet.transform.SetParent (GameObject.Find ("Canvas/EmotionSpawner").transform);
				droplet.transform.localPosition = new Vector3 (0, 0, -1);
				if (difference > 5) {
					droplet.transform.localScale = new Vector3 (2.5f, 2.5f, 2.5f);
				}
			}

			lastScore = score;
		}
	}
}
