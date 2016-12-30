using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public static Queue<GameObject> queue = new Queue<GameObject>();
	private bool isSpawning = false;
	private float time  = 3f;
	public GameObject[] enemies;
	private float newTime = 0;
	private GameObject instance;
	private int createColor = 0;
	private int[] colorNumbers = {1, 2, 4, 3, 5, 6, 7, 0};
	private float yPos;

	IEnumerator SpawnMonster(int index, float time) {
		yield return new WaitForSeconds(time);
		if (time > 2.5f) createColor = colorNumbers[Random.Range(0, 3)]; else
		if (time > 1.8f) createColor = colorNumbers[Random.Range(0, 6)]; 
		else createColor = colorNumbers[Random.Range(0, 7)]; 


		instance = (GameObject)Instantiate(enemies[index], new Vector3(14f, yPos, 0), transform.rotation);
		instance.GetComponent<Enemy>().SetColor(createColor);
		Spawner.queue.Enqueue(instance);
		isSpawning = false;
	}

	// Update is called once per frame
	void Update () {
		if (!isSpawning) {
			isSpawning = true;
			 int enemyIndex = Random.Range(0, enemies.Length);
			 if (time > 0.8f) newTime = time -= 0.04f;
			 switch (enemyIndex) {
			 	case 0:	yPos = 3.9f;	break;
			 	case 1:	yPos = 1.55f;	break;
			 	case 2:	yPos = -1.26f;	break;
			 	case 3:	yPos = -2.41f;	break;
			 }

			 StartCoroutine(SpawnMonster(enemyIndex, newTime));
		}
	}
}
