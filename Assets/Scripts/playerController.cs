using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public int speed;
    public int jumpHeight;

    private Rigidbody2D physics;
    private SpriteRenderer sprite;
    private Animator animationPlayer;


    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animationPlayer = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float MovX = Input.GetAxis("Horizontal");
        physics.velocity = new Vector2(MovX * speed, physics.velocity.y);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            physics.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

        if (physics.velocity.x > 0) sprite.flipX = true;
        else if (physics.velocity.x < 0) sprite.flipX = false;

        AnimatedPlayer();
    }

    private void AnimatedPlayer()
    {
        if (!OnGround()) animationPlayer.Play("Jump");
        else if ((physics.velocity.x > 1 || physics.velocity.x < -1) && physics.velocity.y == 0) animationPlayer.Play("Run");
        else if ((physics.velocity.x > 1 || physics.velocity.x < -1) && physics.velocity.y == 0) animationPlayer.Play("Idle");
        else if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon) animationPlayer.SetInteger("AnimState", 2);
        //Idle
        else
            animationPlayer.SetInteger("AnimState", 0);
    }

    private bool OnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.3f);
        if(hit.collider == null)
        {
            animationPlayer.SetBool("Grounded", false);
            return false;
        }
        else
        {
            animationPlayer.SetBool("Grounded", true);
            return true;
        }

    }
}
