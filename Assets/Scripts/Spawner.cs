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
	private float yPos;

	IEnumerator SpawnMonster(int index, float time) {
		yield return new WaitForSeconds(time);
		if (time > 1.5f) createColor = colorNumbers[Random.Range(0, 3)]; else
		if (time > 0.8f) createColor = colorNumbers[Random.Range(0, 6)]; 
		else createColor = colorNumbers[Random.Range(0, 8)]; 


		instance = (GameObject)Instantiate(enemies[index], new Vector3(13f, yPos, 0), transform.rotation);
		instance.GetComponent<Enemy>().SetColor(createColor);
		isSpawning = false;
	}

	// Update is called once per frame
	void Update () {
		if (!isSpawning) {
			isSpawning = true;
			 int enemyIndex = Random.Range(0, enemies.Length);
			 if (time > 0.3f) newTime = time -= 0.05f;
			 switch (enemyIndex) {
			 	case 0:	yPos = 4.82f;	break;
			 	case 1:	yPos = 1.55f;	break;
			 	case 2:	yPos = -1.26f;	break;
			 	case 3:	yPos = -2.41f;	break;
			 }

			 StartCoroutine(SpawnMonster(enemyIndex, newTime));
		}
	}
}
