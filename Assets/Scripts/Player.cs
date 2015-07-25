using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Sprite deadFrame;
	public Sprite hurtFrame;
	public float fps = 2;
	public Sprite[] frames;
	public AudioClip deadSound;
	public AudioClip peeSound;

	private float frame = 0;
	private float floatYolo = 0;
	private float lastUpdate = 0;
	private bool alive = true;
	private bool movingHealth = false;	
    private AudioSource source;

	// Use this for initialization
	void Start () {
		 source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (alive && Time.time-lastUpdate>1/fps){
			lastUpdate = Time.time;
			if(!movingHealth) changeFrame();
		}

		if (movingHealth && Time.time - floatYolo > 0.5 ) {
			movingHealth = false;
		}
	}

	public void playerHurt() {
		GetComponent<SpriteRenderer>().sprite = hurtFrame;
		movingHealth = true;
		floatYolo = Time.time;
		// StartCoroutine(playerHurtFrame);
	}

	// private IEnumerator playerHurtFrame() {
		
	// 	yield return new WaitForSeconds(0.5f);
	// }

	public void playerDie(){
		alive = false;
		GetComponent<SpriteRenderer>().sprite = deadFrame;
		source.PlayOneShot(deadSound, .5f);
		source.PlayOneShot(peeSound, 1f);
	}

	public void playerBorn(){
		alive = true;
		source.Stop();
	}

	void changeFrame(){
		frame++;
		if (frame==frames.Length){
			frame = 0;
		}
		GetComponent<SpriteRenderer>().sprite = frames[((int)frame)];
	}
}
