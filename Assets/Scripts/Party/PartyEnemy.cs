using UnityEngine;
using System.Collections;

public class PartyEnemy : MonoBehaviour
{

	Animator animator;

	public bool finishedFacing;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void rotate() {
		animator.SetTrigger("FacePlayer");
	}

	public void facing(bool f) {
		this.finishedFacing = f;
	}
}

