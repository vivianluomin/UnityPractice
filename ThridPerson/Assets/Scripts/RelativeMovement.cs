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
    private ControllerColliderHit contact;

    private CharacterController characterController;
    private Animator animator;

    public float pushForce = 3.0f;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
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

        animator.SetFloat("Speed", movment.sqrMagnitude);

        Quaternion tmp = target.rotation;
        target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
        movment = target.TransformDirection(movment);
        target.rotation = tmp;
        Quaternion direction  = Quaternion.LookRotation(movment);
        transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);

        movment *= Time.deltaTime;
       characterController.Move(movment);

        bool hitGround = false;
        RaycastHit hit;
        if(vertSpeed <0 && Physics.Raycast(transform.position,Vector3.down,out hit))
        {
            float check = (characterController.height + characterController.radius) / 1.9f;
            hitGround = hit.distance <= check;
        }


        if (hitGround)
        {
            Debug.Log("Gourd");
            if (Input.GetButtonDown("Jump"))
            {
                vertSpeed = jumpSpeed;
                Debug.Log("jump");
            }
            else
            {
                vertSpeed = -0.1f;
                animator.SetBool("Jumping", false);
            }
        }
        else
        {
            vertSpeed += gravity * 5 * Time.deltaTime;
            if(vertSpeed < terminalVelocity)
            {
                vertSpeed = terminalVelocity;
            }
            if (contact != null)
            {
                animator.SetBool("Jumping", true);
            }
            if (characterController.isGrounded)
            {
                if (Vector3.Dot(movment, contact.normal) < 0)
                {
                    movment = contact.normal * moveSpeed;
                }
                else
                {
                    movment += contact.normal * moveSpeed;
                }
            }
        }
        movment.y = vertSpeed;
        movment *= Time.deltaTime;
        characterController.Move(movment);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        contact = hit;
        Rigidbody body = hit.collider.attachedRigidbody;
        if(body!=null && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * pushForce;
        }
    }

}
