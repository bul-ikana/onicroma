using UnityEngine;
using System.Collections;

public class GameLoop : MonoBehaviour {
	private GameObject bar;
	private GameObject kid;
	public static float scrollSpeed = 10;

	// Use this for initialization
	void Start () {
		bar = GameObject.Find("health");
		kid = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		if(bar.GetComponent<HealthBar>().doDamage(0.01f)){
			GameLoop.scrollSpeed = 0;
			kid.GetComponent<Player>().playerDie();
		}
	}
}
