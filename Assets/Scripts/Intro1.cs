using UnityEngine;
using System.Collections;

public class Intro1 : MonoBehaviour {

	void OnMouseUpAsButton() {
		GameObject.Find("intro2").GetComponent<BoxCollider2D>().enabled = true;
		this.gameObject.SetActive(false);
	}
}
