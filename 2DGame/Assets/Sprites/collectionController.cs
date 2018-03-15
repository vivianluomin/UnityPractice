using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectionController : MonoBehaviour {

    private Vector3 rawPosition;
    private Vector3 hatPosition;
    private float maxWidth;

	// Use this for initialization
	void Start () {
        Vector3 screenPos = new Vector3(Screen.width, 0, 0);
        Vector3 moveWidth = Camera.main.ScreenToWorldPoint(screenPos);

        float hatWidth = GetComponent<Renderer>().bounds.extents.x;
        hatPosition = transform.position;
        maxWidth = moveWidth.x - hatWidth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void FixedUpdate()
    {
        rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hatPosition = new Vector3(rawPosition.x, hatPosition.y, 0);
        hatPosition.x = Mathf.Clamp(hatPosition.x, -maxWidth, maxWidth);
        GetComponent<Rigidbody2D>().MovePosition(hatPosition);
        
    }
}
