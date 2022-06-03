using System;
using Assets.HeroEditor.Common.CharacterScripts;
using UnityEngine;


public class CharacterControl : MonoBehaviour
{
    public float MaxMoveSpeed;
    public float Speed;
    public float PauseMovement;
    public Animator Animator;
    public bool isFlying;

    private bool jump;
    private bool isGrounded;
    private bool player1;
    private bool player2;
    private bool player3;
    private bool player4;

    private int jumps = 0;
    private float temp;
    private float movement;

    private Rigidbody2D rb;
    private PlayerAttack playerAttack;

    public void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        Animator.SetBool("Ready", true);
        rb = this.GetComponent<Rigidbody2D>();

        player1 = false;

        if (this.gameObject.name == "Player1")
        {
            player1 = true;
        }
        else if (this.gameObject.name == "Player2")
        {
            player2 = true;
        }
        else if (this.gameObject.name == "Player3")
        {
            player3 = true;
        }
        else if (this.gameObject.name == "Player4")
        {
            player4 = true;
        }
    }

    public void Update()
    {
        rb = this.GetComponent<Rigidbody2D>();
        if (player1)
        {
            movement = Input.GetAxis("Horizontal");
            jump = Input.GetButtonDown("Jump");
        }
        else if (player2)
        {
            movement = Input.GetAxis("Horizontal1");
            jump = Input.GetButtonDown("Jump1");
        }
        else if (player3)
        {
            movement = Input.GetAxis("Horizontal2");
            jump = Input.GetButtonDown("Jump2");
        }
        else if (player4)
        {
            movement = Input.GetAxisRaw("Horizontal3");
            jump = Input.GetButtonDown("Jump3");
        }
        Move();
    }

    public void Move()
    {
        if (jump && jumps < 3)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0, 300));
            jumps += 1;
        }

        Speed = movement * MaxMoveSpeed;

        if (Speed != 0)
        {
            Turn(Speed);
        }

        if (PauseMovement <= 0 && isGrounded)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
        }
        else if (!isGrounded && !isFlying)
        {
            //rb.AddForce(new Vector2(Speed, 0);
            rb.velocity = new Vector2(0, rb.velocity.y);
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
        else if (!isGrounded && isFlying)
        {
            rb.AddForce(new Vector2(Speed, 0));
        }
        else if (PauseMovement >= 0)
        {
            PauseMovement -= Time.deltaTime;
        }

        Animator.SetBool("Run", isGrounded && Math.Abs(Speed) > 0.01f);
        Animator.SetBool("Jump", !isGrounded);
    }

    public void Turn(float direction)
    {
        if (direction * transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = true;
            isFlying = false;
            jumps = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = true;
            isFlying = false;
            jumps = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = false;
            temp = rb.velocity.x;
        }
    }

}