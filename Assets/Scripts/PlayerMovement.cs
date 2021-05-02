using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = 20f;

    public float jump = 8f;
    Animator anim;
    CharacterController controller;
    public float rotSpeed = 80f;
    float rot = 0f;

    float horizontal;
    float vertical;

    Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 

    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(horizontal, 0.0f, vertical);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButton("Jump"))
            {
                anim.SetBool("IsJumping", true);
                moveDirection.y = jump;
            }
            else
            {
                anim.SetBool("IsJumping", false);
            }
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("IsWalking", true);

                if (Input.GetButton("Jump"))
                {
                    anim.SetBool("IsJumping", true);
                }
                else
                {
                    anim.SetBool("IsJumping", false);
                }
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                    anim.SetBool("IsWalkingBackward", true);
            }
                else
                {
                    anim.SetBool("IsWalkingBackward", false);
                }

                /*
                if (Input.GetKey(KeyCode.A))
                {
                    anim.SetBool("IsWalkingLeft", true);
                }
                else
                {
                    anim.SetBool("IsWalkingLeft", false);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    anim.SetBool("IsWalkingRight", true);
                }
                else
                {
                    anim.SetBool("IsWalkingRight", false);
                }
                if (Input.GetButton("Fire1"))
                {
                    anim.SetBool("Shoot", true);
                }
                else
                {
                    anim.SetBool("Shoot", false);
                }*/
                rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, rot, 0);

            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);

        
    }
    
}
