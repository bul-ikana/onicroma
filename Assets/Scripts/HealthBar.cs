using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	private float health = 0;
	private float last = 0.5f;
	private GameObject bar;
	private float height;
	private bool colChange = false;
	private float timeChanged = 0;

	//Debug values
	// private float vel = .01f;
	// private bool dir = true;

	// Use this for initialization
	void Start () {
		bar = GameObject.Find("life");
		height = GetComponent<Renderer>().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (last!=health){
			health = last;
			bar.transform.localScale = new Vector3(bar.transform.localScale.x, health, bar.transform.localScale.z);
			bar.transform.position = new Vector3(-(height/2.5f)+((height*health)/2f), bar.transform.position.y, bar.transform.position.z);
		}
		if (colChange && Time.time-timeChanged>=0.5f){
			bar.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
			colChange = false;
		}
		/*if(dir){
			heal(vel);
		}else{
			doDamage(vel);
		}*/
	}

	public bool doDamage(float damage) {
		last -= damage;
		if (last<=0){
			last = 0;
			// dir = true;
			return true;
		}
		return false;
	}

	public bool heal(float healed, int color) {
		last += healed;
		changeColor(color);
		if (last>=1){
			last = 1;
			// dir = false;
			return true;
		}
		return false;
	}

	public void changeColor (int color){
		if (color==0) return;
		float r = 0,g = 0,b = 0;
		switch (color) {
				case 1: r = 1f;		g = 1f;		b = 0f;	break;
				case 2: r = 0f;		g = 0f;		b = 1f;	break;
				case 3: r = 0f;		g = .5f;	b = 0f;	break;
				case 4: r = 1f;		g = 0f;		b = 0f;	break;
				case 5: r = 1f;		g = .5f;	b = 0f;	break;
				case 6: r = .8f;	g = 0f;		b = 1f;	break;
				case 7: r = 1f;		g = 1f;		b = 1f;	break;
			}
		colChange = true;
		timeChanged = Time.time;
		bar.GetComponent<Renderer>().material.color = new Color(r, g, b, 1f);
	}
}
