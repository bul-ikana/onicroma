using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour {
    public float tileSizeZ;

    private Vector3 startPosition;

    void Start () {
        startPosition = transform.position;
    }

    void Update () {
        if (GameLoop.scrollSpeed>0){
            float newPosition = Mathf.Repeat(Time.time * GameLoop.scrollSpeed, tileSizeZ);
            transform.position = startPosition + Vector3.left * newPosition;
        }
    }
}