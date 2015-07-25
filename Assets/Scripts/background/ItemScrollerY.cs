using UnityEngine;
using System.Collections;

public class ItemScrollerY : MonoBehaviour {

	public float repeatProbability;
	public float outSize;
	public float maxY;

	private float probMax = 1000;
	private bool appear = false;
	private float started = 0;

	private Vector3 startPosition;
	private Vector3 newPositionVector;

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
				transform.position = newPositionVector + Vector3.left * newPosition;
	        }else if (Random.value*probMax>probMax-repeatProbability){
	        	started = Time.time;
	        	newPositionVector = startPosition + Vector3.up * (Random.value*maxY);
	        	appear = true;
	        }
	    }
	}
}
