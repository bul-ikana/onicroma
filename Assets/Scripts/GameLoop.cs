using UnityEngine;
using System.Collections;

public class GameLoop : MonoBehaviour {
	private HealthBar bar;
	private Player kid;
	private Test beam;
	private bool playing = true;
	private float startBonus = 0;

	public static float scrollSpeed = 10;

	// Use this for initialization
	void Start () {
		bar = GameObject.Find("health").GetComponent<HealthBar>();
		kid = GameObject.Find("player").GetComponent<Player>();
		beam = GetComponent<Test>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playing){
			if (Time.time-startBonus>=10 && beam.isBonus){
				beam.isBonus = false;
				bar.doDamage(.5f);
			}
			if (false){ //Check monster collision with player
				if(bar.doDamage(0.01f)){
					GameLoop.scrollSpeed = 0;
					kid.playerDie();
					playing = false;
				}
			}
			if (true && !beam.isBonus){	//Check beam collision with monster
				if(bar.heal(0.01f)){
					startBonus = Time.time;
					beam.isBonus = true;
				}
			}
		}else if (Input.GetMouseButtonDown(0)){
			bar.heal(.5f);
			GameLoop.scrollSpeed = 10;
			kid.playerBorn();
			playing = true;
		}
	}
}
