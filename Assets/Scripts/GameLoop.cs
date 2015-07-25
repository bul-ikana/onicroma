using UnityEngine;
using System.Collections;

public class GameLoop : MonoBehaviour {
	private GameObject bar;
	private GameObject kid;
	private bool playing = true;
	public static float scrollSpeed = 10;

	// Use this for initialization
	void Start () {
		bar = GameObject.Find("health");
		kid = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		if (playing){
			if(bar.GetComponent<HealthBar>().doDamage(0.01f)){
				GameLoop.scrollSpeed = 0;
				kid.GetComponent<Player>().playerDie();
				playing = false;
			}
		}else if (Input.GetMouseButtonDown(0)){
			bar.GetComponent<HealthBar>().heal(.5f);
			GameLoop.scrollSpeed = 10;
			kid.GetComponent<Player>().playerBorn();
			playing = true;
		}
	}
}
