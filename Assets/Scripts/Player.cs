using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Sprite deadFrame;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playerDie(){
		GetComponent<SpriteRenderer>().sprite = deadFrame;
	}
}
