﻿using UnityEngine;
using System.Collections;

public class TableHandler : MonoBehaviour {

	Vector3 cameraVelocity;
	Vector3 cameraHome;

	float nextPunch = 0;

	// Use this for initialization
	void Start () {
		SelectNew ();
		cameraHome = Camera.main.transform.position;
	}

	public void SelectNew() {
		foreach (TableItem item in GetComponentsInChildren<TableItem> ()) {
			if (item.isGucci ()) {
				item.Select ();
				return;
			}
		}

		Global.LoadLevel ("PartyRail");
	}
	
	// Update is called once per frame
	void Update () {
		float intensity = 0;

		foreach (TableItem item in GetComponentsInChildren<TableItem> ()) {
			if (item.isSelected ()) {
				intensity = item.Distance ();
			}
		}

		if (Global.GetDifficulty () > 10) {
			intensity += Global.GetDifficulty () / 10;
		}

		cameraVelocity += (cameraHome - Camera.main.transform.position).normalized * Time.deltaTime * 5;

		cameraVelocity -= (cameraVelocity.normalized * Time.deltaTime*3);

		if (Time.time > nextPunch) {
			nextPunch = Time.time + (5.0f - intensity)/40;
			cameraVelocity = Random.onUnitSphere * (intensity)/10;
		}

		Camera.main.transform.position += cameraVelocity * Time.deltaTime * 10;

		Global.SubtractPoints (Time.deltaTime*3f*intensity);

//		Camera.main.transform.position = cameraHome + new Vector3 (Mathf.Cos((Mathf.Sin(Time.time*(10*intensity))-Mathf.Cos(Time.time*(2*intensity)))*Mathf.PI*2)*0.2f, 0, Mathf.Sin((Mathf.Cos(Time.time*(11*intensity))-Mathf.Sin(Time.time*(2*intensity)))*Mathf.PI*2)*0.2f);
	}

//	void PunchCamera() {
//		
//	}
}
