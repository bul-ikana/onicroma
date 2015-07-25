using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Sprite deadFrame;
	public float fps = 2;
	public Sprite[] frames;
	private float frame = 0;
	private float lastUpdate = 0;
	private bool alive = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (alive && Time.time-lastUpdate>1/fps){
			lastUpdate = Time.time;
			changeFrame();
		}
	}

	public void playerDie(){
		alive = false;
		GetComponent<SpriteRenderer>().sprite = deadFrame;
	}

	void changeFrame(){
		frame++;
		if (frame==frames.Length){
			frame = 0;
		}
		GetComponent<SpriteRenderer>().sprite = frames[((int)frame)];
	}
}
