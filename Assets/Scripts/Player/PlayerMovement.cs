using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Stats

    //References
    Rigidbody rb;
    BoxCollider boxCollider;
    CharacterStats stats;
    Animator animator;
    FixedJoystick joystick;

    void Start()
    {
        stats = GetComponent<CharacterStats>();
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        SetJoysticks();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;
        Vector3 direction = new Vector3(moveX, 0, moveY).normalized;
        if (direction != Vector3.zero)
        {
            //Move
            rb.AddForce(direction * stats.speed);
            rb.velocity = new Vector3(1, 0, 0);
            Vector3 lookAtPosition = transform.position + direction;
            transform.LookAt(lookAtPosition);
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void SetJoysticks()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    }
}
