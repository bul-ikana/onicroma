using UnityEngine;
using System.Collections;

public class ItemScroller : MonoBehaviour {

	public float scrollSpeed;
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

        if (appear){
        	float newPosition = Mathf.Repeat((Time.time-started) * scrollSpeed, outSize+scrollSpeed);
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
