using UnityEngine;
using System.Collections;

public class GameLoop : MonoBehaviour {
	private HealthBar bar;
	private Player kid;
	private Beam beam;
	private TextMesh scoreTxt;
	private bool playing = true;
	private float startBonus = 0;

	public AudioClip chompSound;
	public AudioClip deadMonsSound;
	public AudioSource source;

	private int score = 0;

	public static float scrollSpeed = 10;

	// Use this for initialization
	void Start () {
		bar = GameObject.Find("health").GetComponent<HealthBar>();
		kid = GameObject.Find("player").GetComponent<Player>();
		beam = GameObject.Find("beam").GetComponent<Beam>();
		scoreTxt = GameObject.Find("Score").GetComponent<TextMesh>();


	}
	
	// Update is called once per frame
	void Update () {
		if (playing){
			scoreTxt.text = (int)(Time.time * 10) * 100+ "";
			if (Time.time-startBonus>=5 && beam.isBonus){
				beam.isBonus = false;
				bar.doDamage(.5f);
			}
			if (beam.isBonus) {
				bar.changeColor(beam.color);
			}
			if(Spawner.queue.Count > 0){
				if (Spawner.queue.Peek().transform.position.x < -4){ //Check monster collision with player
					kid.GetComponent<Player>().playerHurt();
					Spawner.queue.Dequeue();
					source.PlayOneShot(chompSound, 1f);
					if(bar.doDamage(0.25f)){
						gameOver();
					}
				}
			
				if(Spawner.queue.Peek().transform.position.x < 8){
				if (beam.isBonus) {
					GameObject temp = Spawner.queue.Dequeue();
					Destroy(temp);
					source.PlayOneShot(deadMonsSound, .5f);
					source.time = .15f;
					return;
				}
					if (beam.color == Spawner.queue.Peek().GetComponent<Enemy>().colorEnemy) {	//Check beam collision with monster
						GameObject temp = Spawner.queue.Dequeue();
						Destroy(temp);
						source.PlayOneShot(deadMonsSound, .5f);
						source.time = .15f;


						if(!beam.isBonus){

							if(bar.heal(0.05f, beam.color)){
								startBonus = Time.time;
								beam.isBonus = true;
							}
						}
					} else if(beam.color != 0){
						if(bar.doDamage(0.008f)){
							gameOver();
						}
					}
				}
			}
		}else if (Input.GetMouseButtonDown(0)){
			// bar.heal(.5f);
			GameLoop.scrollSpeed = 10;
			kid.playerBorn();
			playing = true;
		}
	}

	void gameOver() {
		GameLoop.scrollSpeed = 0;
		kid.playerDie();
		playing = false;	
	}
}
