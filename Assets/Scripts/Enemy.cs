using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float r;
	private float g;
	private float b;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetColor(int color) {
		switch (color) {
			case 0: r = 0f;	g = 0f;		b = 0f;	break;
			case 1: r = 1f;	g = 1f;		b = 0f;	break;
			case 2: r = 0f;	g = 0f;		b = 1f;	break;
			case 3: r = 0f;	g = .5f;	b = 0f;	break;
			case 4: r = 1f;	g = 0f;		b = 0f;	break;
			case 5: r = 1f;	g = .5f;	b = 0f;	break;
			case 6: r = .5f;	g = 0f;	b = 1f;	break;
			case 7: r = 1f;	g = 1f;		b = 1f;	break;
		}
		this.gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b, 1);
	}
}
