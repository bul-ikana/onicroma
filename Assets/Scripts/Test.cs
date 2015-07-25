using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	GameObject beam;
	int color;
	float r;
	float g;
	float b;

	// Use this for initialization
	void Start () {
		r = g = b = 0;
		beam = GameObject.Find("Beam");
	}
	
	// Update is called once per frame
	void Update () {
		// iTween.ColorTo(
		// 	beam,
		// 	iTween.Hash(
		// 		"r", 255, 
		// 		"g", 255, 
		// 		"b", 255, 
		// 		"time", 0f
		// 	)
		// );
		beam.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 1);
		color = 0;
        if (Input.touchCount != 0) {
        	foreach (Touch t in Input.touches) {
        		Vector3 click = Camera.main.ScreenToWorldPoint(t.position);
        		RaycastHit2D[] hits = Physics2D.LinecastAll (click, click);
        		if (hits.Length != 0) {
        			switch (hits[0].transform.gameObject.GetComponent<Buttons>().SayMyName()) {
        				case "Yellow":	color += 1;	break;
        				case "Blue":	color += 2;	break;
        				case "Red":		color += 4;	break;
        			}
        		}
        	}
        	// Debug.Log(color);
			// 1 amarillo
			// 2 azul
			// 3 verda
			// 4  rojo
			// 5 naranja
			// 6 morado
			// 7 blanco
			switch (color) {
				case 1: r = 1f;	g = 1f;		b = 0f;	break;
				case 2: r = 0f;	g = 0f;		b = 1f;	break;
				case 3: r = 0f;	g = .5f;	b = 0f;	break;
				case 4: r = 1f;	g = 0f;		b = 0f;	break;
				case 5: r = 1f;	g = .5f;	b = 0f;	break;
				case 6: r = .5f;	g = 0f;		b = 1f;	break;
				case 7: r = 1f;	g = 1f;		b = 1f;	break;
			}
        } else {
        	r = 0;	g = 0;	b = 0;
        }
		
		beam.GetComponent<Renderer>().material.color = new Color(r, g, b, 1);
		Debug.Log(beam.GetComponent<Renderer>().material.color);
	}
}
