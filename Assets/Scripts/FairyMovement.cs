using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class FairyMovement : MonoBehaviour
{
    public PhotonView photonView;
    public Animator animator;

    public int flyingSpeed = 20;

    public bool facingLeft = false;

    public float moveX;
    public float moveY;

    private Vector3 selfPosition;

    public bool devTesting = false;

    public string name = "2ndPlayer";

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
            // else SmoothNetMovement();
        }
        else
            PlayerMove();
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");

        //animator.SetFloat("Speed", Mathf.Abs(moveX));

        if (moveX < 0.0f && facingLeft == true)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingLeft == false)
        {
            FlipPlayer();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * flyingSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, flyingSpeed * 1f);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, flyingSpeed * -1f);
        }

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
        if (collision.gameObject.tag == "Ground")
        {
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bush")
        {
            other.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bush")
        {
            other.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1f);
        }
    }

    /*  private void SmoothNetMovement()
      {
          gameObject.GetComponent<Rigidbody2D>().position = Vector3.Lerp(transform.position, selfPosition, Time.deltaTime * 10);
          //animator.SetFloat("Speed", Mathf.Abs(moveX));
      }

      private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
      {
          if (stream.IsWriting)
          {
              stream.SendNext(gameObject.GetComponent<Rigidbody2D>().position);
              //stream.SendNext(animator.GetFloat("Speed"));
          }
          else
          {
              selfPosition = (Vector3)stream.ReceiveNext();
              selfSpeed = (float)stream.ReceiveNext();
          }
      } */
}