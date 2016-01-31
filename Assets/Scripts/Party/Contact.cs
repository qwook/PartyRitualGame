using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour {

	Camera camera;
	public GameObject circle;

	SpriteRenderer spriteInContact;
	public float currentContactLength = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		camera = GetComponent<Camera>();
		checkForContact ();

		if (currentContactLength) {
		}

	}

	void checkForContact () {
		
		Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 100)) {
			Debug.DrawLine (ray.origin, hit.point, Color.cyan);
			circle.transform.position = hit.point;

			SpriteRenderer newSpriteInContact = hit.transform.GetComponentInParent<SpriteRenderer> ();
			bool facing = hit.transform.GetComponentInParent<Partier> ().finishedFacing; 
			//this is tells us if the turning animation has finished and the partier is in the 'facing' (the screen) state.
			if (facing == true) {

				//increase intensity of contact
				if (spriteInContact == newSpriteInContact) {
					currentContactLength+=.01f;
					spriteInContact.color = new Color (1.0f, 1.0f - currentContactLength, 1.0f - currentContactLength, 1.0f);
				} else {
					//we have a new person in contact
					if (spriteInContact)
						spriteInContact.color = Color.white;
					newSpriteInContact.color = new Color (1.0f, 0, 0, 1.0f);
					currentContactLength = 0;
				}
			} else {
				//not making eye contact
				if (spriteInContact)
					spriteInContact.color = Color.white;
				newSpriteInContact.color = Color.green;
				currentContactLength = 0;
			}

			spriteInContact = newSpriteInContact;
			

		} else {
			//not looking at anybody
			if (spriteInContact) {
				spriteInContact.color = Color.white;
			}
			spriteInContact = null;
			Debug.DrawRay(ray.origin, ray.direction, Color.red);
		}
	}
}
