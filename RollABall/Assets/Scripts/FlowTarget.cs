using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowTarget : MonoBehaviour {

    public Transform playerTransform;

    private Vector3 offest;

	// Use this for initialization
	void Start () {
        offest = transform.position - playerTransform.position;
           
    
	}
	
	// Update is called once per frame
	void Update () {

       transform.position = playerTransform.position + offest;
	}
}
