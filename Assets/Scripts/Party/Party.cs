using UnityEngine;
using System.Collections;

public class Party : MonoBehaviour {

	public Transform[] partyGoers;
	public int numPartyGoers = 5;

	public string goodSceneName = "Table";
	public string badSceneName = "Handshake";



	public int xMin = -50, xMax = 50;
	public int yMin = -20, yMax = 20;
	public int zMin = 10, zMax = 15;


	void Start () {
		int position;
		int x;
		int y; 
		int z;

		for (int i = 0; i < numPartyGoers; i++) {
			position = Random.Range (0, partyGoers.Length);
			x = Random.Range (xMin, xMax);
			y = Random.Range (yMin, yMax);
			z = Random.Range (zMin, zMax);

			Instantiate(partyGoers[position], new Vector3(x, y, z), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
