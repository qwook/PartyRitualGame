using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour {

	public Camera camera;
	public GameObject circle;

	public float speed = 10.0F;
	public float rotationSpeed = 100.0F;

	SpriteRenderer spriteInContact;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float translationY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		camera.transform.Translate (translationX, translationY, 0);

		checkForContact ();

	}

	void checkForContact () {
		Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 100)) {
			Debug.DrawLine (ray.origin, hit.point, Color.cyan);
			circle.transform.position = hit.point;


			SpriteRenderer newSpriteInContact = hit.transform.GetComponentInParent<SpriteRenderer> ();

			if (spriteInContact == newSpriteInContact) {
				spriteInContact.color = new Color(255,0,0, spriteInContact.color.a + 5);
			} else {
				if(spriteInContact) spriteInContact.color = Color.white;
				newSpriteInContact.color = new Color(255,0,0, 100);
				spriteInContact = newSpriteInContact;
			}

		} else {
			if (spriteInContact) {
				spriteInContact.color = Color.white;
			}
			spriteInContact = null;
			Debug.DrawRay(ray.origin, ray.direction, Color.red);
		}
	}
}
