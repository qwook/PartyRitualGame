using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeImage : MonoBehaviour {

	SpriteRenderer sprite;
	float normalizedFadeTime;


	public string nextLevel = "";
	public float fadeOutTime = 1f;
	public float waitTime = 1f;

	private bool fadedIn = false;
	private bool waited = false;


	// Use this for initialization
	void Start () {
		sprite = GetComponentInParent<SpriteRenderer> ();
		normalizedFadeTime = 1f / fadeOutTime;
		sprite.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {

		if (!fadedIn) {
			fadeIn ();
		} else if (!waited) {

			StartCoroutine(wait());

		} else {
			fadeOut ();
		}

	}

	IEnumerator wait() {
		yield return new WaitForSeconds (waitTime);
		waited = true;
	}

	void fadeIn() {
		Color c = sprite.color;
		float fade = c.b + Time.deltaTime * normalizedFadeTime;
		c.b = fade;
		c.r = fade;
		c.g = fade;
		sprite.color = c;
		if (sprite.color.b >= 1) {
			fadedIn = true;
		}
	}

	void fadeOut() {
		Color c = sprite.color;
		float fade = c.b - Time.deltaTime * normalizedFadeTime;

		c.b = fade;
		c.r = fade;
		c.g = fade;
		sprite.color = c;

		if (sprite.color.b <= 0) {
			Debug.Log ("supppers");
			SceneManager.LoadScene (nextLevel, LoadSceneMode.Single);
		}
	}
}
