using UnityEngine;
using System.Collections;

public class TextLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<MeshRenderer> ().sortingLayerName = "Text";
		gameObject.GetComponent<MeshRenderer> ().sortingOrder = 1;
	}
}
