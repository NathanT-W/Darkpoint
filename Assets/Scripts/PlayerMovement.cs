using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMovement : MonoBehaviour
{
    public PhotonView photonView;
    public Animator animator;

    public int playerSpeed = 20;
    public int playerJumpPower = 4000;

    public bool facingLeft = false;
    public bool canJump;

    public float moveX;

    private Vector3 selfPosition;

    public bool devTesting = false;

    public string name = "player1";

    private float selfSpeed;

    void Start()
    {
        photonView = (PhotonView)gameObject.GetComponent<PhotonView>();
        if (photonView.IsMine)
            Camera.main.GetComponent<CameraFollow>().playerTransform = transform;
    }

    private void Update()
    {
        if (!devTesting)
        {
            if (photonView.IsMine)
                PlayerMove();
            else SmoothNetMovement();
        }
        else
            PlayerMove();
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(moveX));

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

    private void SmoothNetMovement()
    {
        transform.position = Vector3.Lerp(transform.position, selfPosition, Time.deltaTime * 10);
        animator.SetFloat("Speed", Mathf.Abs(moveX));
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(animator.GetFloat("Speed"));
        }
        else
        {
            selfPosition = (Vector3)stream.ReceiveNext();
            selfSpeed = (float)stream.ReceiveNext();
        }
    }
}
