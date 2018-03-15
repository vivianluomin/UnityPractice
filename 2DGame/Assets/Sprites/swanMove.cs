





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swanMove : MonoBehaviour {

    private float moveSpeed = 4;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(-5, -3, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < 7)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(-5, -3, 0);
        }
	}
}
