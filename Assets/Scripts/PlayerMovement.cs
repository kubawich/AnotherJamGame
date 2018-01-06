using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer renderer;
    public AudioSource audiosrc;
    [Header("All Animations")]
    public Sprite[] PlayerSpriteState;
    [Header("All Sounds")]
    public AudioClip[] PlayerAudioState;
    new Rigidbody2D rb;
    [Space()]
    [Range(1,10)]
    public int fallMultipier;
    [Range(1, 10)]
    public int smallFallMultipier;
    [Range(1, 10)]
    public int jumpVelocity;
    [Range(1, 10)]
    public int moveSpeed;
    [Range(1, 10)]
    public int dashPower;
    private bool isInAir, doubleJumped;
    private bool isAbleToJump;
    public bool goLeft, goRight;

    void Start()
    {                      
        renderer    = GetComponent<SpriteRenderer>();
        rb          = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Stopm
        Stopm();
    }


    void Update()
    {
        //Right
        if (Input.GetKey(KeyCode.D) || goRight)
        {
            renderer.flipX = true ? false : true;
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0);
        }
        //Left
        if (Input.GetKey(KeyCode.A) || goLeft)
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0);
            renderer.flipX = true;
        }
        //Check that double jumped
        if (isInAir && Input.GetKeyDown(KeyCode.W))
        {
            doubleJumped = true; isAbleToJump = false;
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.W) && !doubleJumped)
        {
            Jump();
        }
        //Dash
        if (isInAir && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
    }

    //Dash
    public void Dash()
    {
        int i = renderer.flipX ? -1 : 1;
        transform.Translate(new Vector3(dashPower * i, 0, 0) * 1.8f);
    }

    //Jump
    public void Jump()
    {
        if (isAbleToJump)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            renderer.sprite = PlayerSpriteState[1] as Sprite;

            //Audio
            audiosrc.clip = PlayerAudioState[1];
            audiosrc.pitch = UnityEngine.Random.Range(.8f, 1.2f);
            audiosrc.PlayOneShot(PlayerAudioState[1], UnityEngine.Random.Range(.45f, 1f));
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    //Stomp
    public void Stopm()
    {
        if (isInAir && Input.GetMouseButtonDown(1))
        {
            rb.velocity = Vector2.down * jumpVelocity * 4;
        }
    }

    //Event left enter
    public void MoveLeftEnter()
    {
        goLeft = true;
    }
    //Event left exit
    public void MoveLeftExit()
    {
        goLeft = false;
    }
    //Event right enter
    public void MoveRightEnter()
    {
        goRight = true;
    }
    //Event right exit
    public void MoveRightExit()
    {
        goRight = false;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        isInAir = false;
        doubleJumped = false;
        isAbleToJump = true;
        renderer.sprite = PlayerSpriteState[0] as Sprite;
    }

    void OnCollisionExit2D(Collision2D c)
    {
        isInAir = true;
    }
}