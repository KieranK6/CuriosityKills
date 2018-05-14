using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //CharacterController charControl;
    //public float walkSpeed;


    //void Awake()
    //{
    //    charControl = GetComponent<CharacterController>();
    //}

    //void Update()
    //{
    //    MovePlayer();
    //}

    //void MovePlayer()
    //{
    //    float horiz = Input.GetAxis("Horizontal");
    //    float vert = Input.GetAxis("Vertical");

    //    Vector3 moveDirSide = transform.right * horiz * walkSpeed;
    //    Vector3 moveDirForward = transform.forward * vert * walkSpeed;

    //    charControl.SimpleMove(moveDirSide);
    //    charControl.SimpleMove(moveDirForward);

    //}

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotateSpeed = 6;
    private Vector3 moveDirection = Vector3.zero;

    public bool disableMovement = false;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if(!disableMovement)
        {
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;

                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;

            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
        
    }
}
