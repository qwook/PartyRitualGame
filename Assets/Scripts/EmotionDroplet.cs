using UnityEngine;
using System.Collections;

public class EmotionDroplet : MonoBehaviour {

	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		velocity = Random.onUnitSphere * 50.0f;
		velocity.y = 500.0f;
		velocity.z = 0;

	}
	
	// Update is called once per frame
	void Update () {
		velocity.y -= 9.8f * 100.0f * Time.deltaTime;
		transform.position = transform.position + velocity * Time.deltaTime;
		if (transform.position.y < -200) {
			GameObject.Destroy (this.gameObject);
		}
	}
}
