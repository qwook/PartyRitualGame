using UnityEngine;
using System.Collections;

public class PlayerView : MonoBehaviour
{
	public Camera camera;

	public int xMin = -30;
	public int xMax = 30;
	public int yMin = 0;
	public int yMax = 2;

	public float xSpeed = 20.0F;
	public float ySpeed = 100.0F;

	// Use this for initialization
	void Start ()
	{
		camera = GetComponent<Camera> ();
		
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float translationY = Input.GetAxis("Vertical") * xSpeed * Time.deltaTime;
		float translationX = Input.GetAxis("Horizontal") * ySpeed * Time.deltaTime;

		camera.transform.Translate (translationX, translationY, 0);

		Vector3 v3 = camera.transform.position;
		v3.x = Mathf.Clamp (v3.x, xMin, xMax);
		v3.y = Mathf.Clamp (v3.y, yMin, yMax);
		v3.z = 0;
		camera.transform.position = v3;

	}
}

