using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseLook : MonoBehaviour {

    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitvityHor = 3.0f;
    public float sensitviityVert = 3.0f;

    public float minimumVert = -45.0f;
    public float maxmumVert = 45.0f;

    private float _rotationX = 0;

    // Use this for initialization
    void Start () {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
	}

    // Update is called once per frame
    void Update() {
        if (axes == RotationAxes.MouseX)
        {
             transform.Rotate(0, Input.GetAxis("Mouse X")*sensitvityHor, 0);

        }else if(axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y")*sensitviityVert;
            Console.WriteLine(_rotationX);
            _rotationX = Mathf.Clamp(_rotationX,minimumVert
                , maxmumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

       
       
        }
        else
        {
            _rotationX  -= -Input.GetAxis("Mouse Y") * sensitviityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maxmumVert);

            float delata = Input.GetAxis("Mouse X") * sensitvityHor;
            float rotationY = transform.localEulerAngles.y + delata;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
     
         
        }
    }
}
