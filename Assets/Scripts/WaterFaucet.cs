using UnityEngine;
using System.Collections;

public class WaterFaucet : MonoBehaviour {

	private ArrayList waterList = new ArrayList();
	private float step = 0;

	private bool stop = false;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			GameObject water;

			if (i % 3 == 0) {
				water = (GameObject)Instantiate (Resources.Load ("CleanWater"));
			} else {
				water = (GameObject)Instantiate (Resources.Load ("DirtyWater"));
			}

			waterList.Add (water);
			water.transform.SetParent (transform);
			water.transform.localPosition = new Vector3(0, 0, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Global.loadBadLevel)
			return;
		
		if (stop)
			return;

		step += Time.deltaTime;

		int i = 0;
		foreach (GameObject water in waterList) {
			i++;
			Vector3 position = water.transform.localPosition;
			position.y = -(i + step) % waterList.Count + 7;
			water.transform.localPosition = position;
		}

		if (GameObject.Find ("Hand1").GetComponent<Hand>().IsClean () && GameObject.Find ("Hand2").GetComponent<Hand>().IsClean()) {
			stop = true;
			Global.LoadLevel ("Party");
		}

	}
}
