using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	GameObject beam;

	// Use this for initialization
	void Start () {
		beam = GameObject.Find("Beam");
		Debug.Log(beam);
		// vectors
	// iTween.FadeTo(enemy1.transform.GetChild(0).gameObject, 1, 0);
	// 	iTween.FadeTo(enemy2.transform.GetChild(0).gameObject, 1, 0);
	// 	iTween.FadeTo(enemy3.transform.GetChild(0).gameObject, 1, 0);
	// 	iTween.FadeTo(enemy4.transform.GetChild(0).gameObject, 1, 0);
	// 	iTween.FadeTo(enemy5.transform.GetChild(0).gameObject, 1, 0);

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount != 0) {
        	foreach (Touch t in Input.touches) {
        		Vector3 click = Camera.main.ScreenToWorldPoint(t.position);
        		RaycastHit2D[] hits = Physics2D.LinecastAll (click, click);
        		if (hits.Length != 0) {
        			hits[0].transform.gameObject.GetComponent<Buttons>().SayMyName();
        			iTween.ColorTo(
        				beam,
        				iTween.Hash(
        					"r", 255, 
        					"g", 255, 
        					"b", 0, 
        					"time", 0f
        				)
        			);
        		}
        	}
        }
	}
}
