using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameInput : MonoBehaviour {


	public GameObject input1;
	public GameObject input2;
	public GameObject input3;

	public string name;

	// Use this for initialization
	void Start () {
//		GUI.SetNextControlName("Input1");
		GUI.FocusControl ("Input1");
		name = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void submitSelected() {
		string in1 = input1.transform.FindChild ("Text").GetComponent<Text> ().text;
		string in2 = input2.transform.FindChild ("Text").GetComponent<Text> ().text;
		string in3 = input2.transform.FindChild ("Text").GetComponent<Text> ().text;

		name = in1 + in2 + in3;
		Debug.Log (name);

//		
	}


}
