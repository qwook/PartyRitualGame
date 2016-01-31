using UnityEngine;
using System.Collections;

public class IncomingHand : MonoBehaviour {

	public Sprite[] sprites;
	private bool gucci = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
			Global.SubtractPoints (20);
			gucci = true;
		} else {
			GameObject.Find ("Result").GetComponent<Animator>().SetTrigger("Bad");
			Global.SubtractPoints (20);
		}
	}

	public void End() {
		if (gucci) {
			Global.LoadLevel ("Bathroom");
		}
	}
}
