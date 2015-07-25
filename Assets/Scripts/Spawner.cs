using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	private bool isSpawning = false;
	private float time  = 2f;
	public GameObject[] enemies;
	private float newTime = 0;
	private GameObject instance;
	private int createColor = 0;
	private int[] colorNumbers = {1, 2, 4, 3, 5, 6, 7, 0};

	IEnumerator SpawnMonster(int index, float time) {
		yield return new WaitForSeconds(time);
		if (time < 1.5f) createColor = colorNumbers[Random.Range(0, 2)]; else
		if (time < 1f) createColor = colorNumbers[Random.Range(0, 5)]; else
		if (time < .5f) createColor = colorNumbers[Random.Range(0, 5)]; 


		instance = (GameObject)Instantiate(enemies[index], transform.position, transform.rotation);
		instance.GetComponent<Enemy>().SetColor(createColor);
		isSpawning = false;
	}

	// Update is called once per frame
	void Update () {
		if (!isSpawning) {
			isSpawning = true;
			 int enemyIndex = Random.Range(0, enemies.Length);
			 if (time > 0.3f) newTime -= 0.05f;

			 StartCoroutine(SpawnMonster(enemyIndex, newTime));
		}
	}
}
