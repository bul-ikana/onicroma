using UnityEngine;
using System.Collections;

public class ItemScroller : MonoBehaviour {

	public float repeatProbability;
	public float outSize;
	private float probMax = 1000;
	private bool appear = false;
	private float started = 0;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameLoop.scrollSpeed>0){
	        if (appear){
	        	float newPosition = Mathf.Repeat((Time.time-started) * GameLoop.scrollSpeed, outSize+GameLoop.scrollSpeed);
	        	if (newPosition>=outSize){
	        		appear = false;
	        	}
				transform.position = startPosition + Vector3.left * newPosition;
	        }else if (Random.value*probMax>probMax-repeatProbability){
	        	started = Time.time;
	        	appear = true;
	        }
		}
	}
}
