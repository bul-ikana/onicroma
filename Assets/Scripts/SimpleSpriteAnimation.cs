using UnityEngine;
using System.Collections;

public class SimpleSpriteAnimation : MonoBehaviour {

	public float fps = 2;
	private float frame = 0;
	private float lastUpdate = 0;
	public Sprite[] frames;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time-lastUpdate>1/fps){
			lastUpdate = Time.time;
			changeFrame();
		}
	}

	void changeFrame(){
		frame++;
		if (frame==frames.Length){
			frame = 0;
		}
		GetComponent<SpriteRenderer>().sprite = frames[((int)frame)];
	}
}
