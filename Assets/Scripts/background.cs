using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {

	private float vel = 10f;

	private GameObject floor1;
	private GameObject floor2;

	// Use this for initialization
	void Start () {
		/*floor1 = GameObject.Find("floor1");
		Debug.Log(floor1);

		floor2 = GameObject.Find("floor2");
		Debug.Log(floor2);*/
	}
	
	// Update is called once per frame
	void Update () {
		/*float translation = Time.deltaTime * vel;
		if (floor1.transform.position)
        floor1.transform.Translate(-translation, 0, 0);
        floor2.transform.Translate(-translation, 0, 0);*/
	}
}
