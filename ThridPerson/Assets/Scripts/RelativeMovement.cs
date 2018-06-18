using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour {

    [SerializeField] private Transform target;

    public float rotSpeed = 15.0f;
    public float moveSpeed = 6.0f;

    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -10.5f;

    private float vertSpeed;

    private CharacterController characterController;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        vertSpeed = minFall;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movment = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        if (horInput != 0 || verInput != 0)
        {
            movment.x = horInput *moveSpeed;
            movment.z = verInput*moveSpeed;

            movment = Vector3.ClampMagnitude(movment, moveSpeed);
        }

        Quaternion tmp = target.rotation;
        target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
        movment = target.TransformDirection(movment);
        target.rotation = tmp;
        Quaternion direction  = Quaternion.LookRotation(movment);
        transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);

        movment *= Time.deltaTime;
       characterController.Move(movment);

        if (characterController.isGrounded)
        {
            Debug.Log("Gourd");
            if (Input.GetButtonDown("Jump"))
            {
                vertSpeed = jumpSpeed;
                Debug.Log("jump");
            }
            else
            {
                vertSpeed = minFall;
            }
        }
        else
        {
            vertSpeed += gravity * 5 * Time.deltaTime;
            if(vertSpeed < terminalVelocity)
            {
                vertSpeed = terminalVelocity;
            }
        }

        movment.y = vertSpeed;
        movment *= Time.deltaTime;
        characterController.Move(movment);
    }
}
