using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public int playerSpeed = 20;
    public int playerJumpPower = 2000;

    public bool facingLeft = false;
    public bool canJump;

    public float moveX;

    void Update()
    {
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
        Debug.Log("Player has collided with" + collision.collider.name);
        if( collision.gameObject.tag == "Ground") 
        {
            canJump = true;
        }
    }
}
