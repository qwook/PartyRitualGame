using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour {

	public Camera camera;
	public GameObject circle;

	public float speed = 10.0F;
	public float rotationSpeed = 100.0F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float translationY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		camera.transform.Translate (translationX, translationY, 0);
	}
}
