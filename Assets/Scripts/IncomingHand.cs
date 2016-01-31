using UnityEngine;
using System.Collections;

public class IncomingHand : MonoBehaviour {

	public Sprite[] sprites;
	private bool gucci = false;

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.speed = 1f + (float) Global.GetDifficulty ()/16;

	}
	
	// Update is called once per frame
	void Update () {
		if (gucci) {
			Global.LoadLevel ("Bathroom");
		}
	}

	public void GetHandSprite() {
		int rand = Random.Range (0, sprites.Length);
		this.GetComponent<SpriteRenderer> ().sprite = sprites [rand];
	}

	public void GetNewHandSprite() {
		int rand = Random.Range (0, sprites.Length-1);
		this.GetComponent<SpriteRenderer> ().sprite = sprites [rand];
	}

	public void Shake() {
		if (GameObject.Find ("MyFist").GetComponent<SpriteRenderer> ().sprite == this.GetComponent<SpriteRenderer> ().sprite) {
			GameObject.Find ("Result").GetComponent<Animator>().SetTrigger("Good");
			Global.AddPoints (20);
		} else {
			GameObject.Find ("Result").GetComponent<Animator>().SetTrigger("Bad");
			Global.SubtractPoints (20);
		}
	}

	public void End() {
		gucci = true;
	}
}
