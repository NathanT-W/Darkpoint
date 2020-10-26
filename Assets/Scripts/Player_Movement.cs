using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_Movement : NetworkBehaviour
{
    public int playerSpeed = 20;
    public int playerJumpPower = 2000;

    public bool facingLeft = false;
    public bool canJump;

    public float moveX;

    void Start()
    {
        if(this.isLocalPlayer)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().playerTransform=transform;
        }
    }

    void Update()
    {
        if(this.isLocalPlayer)
        PlayerMove();
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && canJump == true)
        {
            Jump();
        }

        if(moveX < 0.0f && facingLeft == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingLeft == true)
        {
            FlipPlayer();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity =  new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        canJump = false;
    }

    void FlipPlayer()
    {
        facingLeft = !facingLeft;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "Ground") 
        {
            canJump = true;
        }
    }

}
