using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {

    private CharacterController characterController;

    public float speed = 3.0f;

	// Use this for initialization
	void Start () {
		_characaterController = GetCom
	}
	
	// Update is called once per frame
	void Update () {

        float deltaX = Input.GetAxis("Horizaontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        transform.Translate(deltaX*Time.deltaTime, 0, deltaZ*Time.deltaTime);
		
	}
}
