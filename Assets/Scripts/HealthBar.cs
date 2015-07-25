using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	private float health = 0;
	private float last = 0.5f;
	private GameObject bar;
	private float height;

	//Debug values
	// private float vel = .01f;
	// private bool dir = true;

	// Use this for initialization
	void Start () {
		bar = GameObject.Find("life");
		height = GetComponent<Renderer>().bounds.size.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (last!=health){
			health = last;
			bar.transform.position = new Vector3(bar.transform.position.x, (height*health)/2f, bar.transform.position.z);
			bar.transform.localScale = new Vector3(bar.transform.localScale.x, health, bar.transform.localScale.z);
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

	public bool heal(float healed) {
		last += healed;
		if (last>=1){
			last = 1;
			// dir = false;
			return true;
		}
		return false;
	}
}
