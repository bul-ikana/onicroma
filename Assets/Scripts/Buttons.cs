using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	public string name;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string SayMyName() {
		Debug.Log(name);
		return name;
	}
}
