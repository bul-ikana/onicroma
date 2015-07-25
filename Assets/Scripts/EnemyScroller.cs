using UnityEngine;
using System.Collections;

public class EnemyScroller : MonoBehaviour {

	public float outSize;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameLoop.scrollSpeed > 0) {
	        float movespeed = 0.0f;
	        movespeed-= .1f;
	        transform.Translate(movespeed, 0, 0);
	        if (transform.position.x <= outSize){
	        	Destroy(gameObject);
	        }
		}
	}
}
