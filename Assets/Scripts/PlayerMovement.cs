using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float gravity = 20f;

    public float jump = 8f;
    private Animator animator;
    CharacterController controller;
    public float rotSpeed = 80f;
    float rot = 0f;

    float horizontal;
    float vertical;

    Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
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
                moveDirection.y = jump;
            }

            rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rot, 0);

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
    
}
