using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject ball;
    private float maxWidth;
    private float time;
    private GameObject newball;

	// Use this for initialization
	void Start () {
        Vector3 screemPos = new Vector3(Screen.width, 0, 0);
        Vector3 moveWidth = Camera.main.ScreenToWorldPoint(screemPos);
        float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = moveWidth.x - ballWidth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void FixedUpdate()
    {
        time = Random.Range(1.5f, 2.0f);
        float posX = Random.Range(-maxWidth, maxWidth);
        Vector3 spawnPosition = new Vector3(posX, transform.position.y, 0);
        newball = (GameObject)Instantiate(ball, spawnPosition, Quaternion.identity);
        Destroy(newball, 10);
    }
}
