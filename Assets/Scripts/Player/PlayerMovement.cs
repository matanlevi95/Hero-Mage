using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Stats

    //References
    Rigidbody rb;
    CharacterStats stats;
    Animator animator;
    FixedJoystick joystick;

    float moveX;
    float moveY;

    void Start()
    {
        stats = GetComponent<CharacterStats>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        SetJoysticks();
    }

    private void Update()
    {
        moveX = joystick.Horizontal;
        moveY = joystick.Vertical;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {

        Vector3 direction = new Vector3(moveX, 0, moveY).normalized;
        if (direction != Vector3.zero)
        {
            //Move
            rb.velocity = direction * stats.speed;
            //rb.AddForce(direction * stats.speed);
            Vector3 lookAtPosition = transform.position + direction;
            transform.LookAt(lookAtPosition);
            animator.SetBool("walking", true);
        }
        else animator.SetBool("walking", false);

    }

    void SetJoysticks()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    }
}
