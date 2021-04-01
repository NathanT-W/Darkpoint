using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 8;
    public bool CanMove = true;
    public bool MoveRight;
    public float randTime;
    public float turnTime = 5;
    public GameObject ResetSpawnPoint;
    public GameObject Player;
    public Animator animator;

    public bool MoveLeftRightRandom;
    public bool MoveLeftRightDelay;
    public bool FollowPlayer;

    void Start()
    {
        

        if (MoveLeftRightRandom && !MoveLeftRightDelay && !FollowPlayer)
        {
            Invoke("ChangeDirectionRandom", 1);
            ResetSpawnPoint = GameObject.Find("VanSpawnPoint2");
        }
        else if(!MoveLeftRightRandom && !MoveLeftRightDelay && FollowPlayer)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void ChangeDirectionRandom()
    {
        float randTime = Random.Range(1, 10);

        MoveRight = !MoveRight;

        Invoke("ChangeDirectionRandom", randTime);
    }

    void Update()
    {
        if (CanMove)
        {
            animator.SetFloat("Speed", speed);

            if (FollowPlayer)
            {
                transform.localScale = new Vector2(-1 , 1);
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, 2* speed * Time.deltaTime);
            }
            else if (MoveRight)
            {
                
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                animator.SetFloat("Speed", speed);
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(1, 1);
            }

        }
        else animator.SetFloat("Speed", 0);
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (!FollowPlayer)
        {
            if (trigger.gameObject.tag == "TurnRight")
            {
                if (MoveLeftRightDelay)
                {
                    StartCoroutine(WaitThenTurn());
                }
                else if (MoveLeftRightRandom)
                {
                    MoveRight = true;
                }
            }
            else if (trigger.gameObject.tag == "TurnLeft")
            {
                if (MoveLeftRightDelay)
                {
                    StartCoroutine(WaitThenTurn());
                }
                else if (MoveLeftRightRandom)
                {
                    MoveRight = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Fairy"))
        {
            collider.transform.position = ResetSpawnPoint.transform.position;
            Debug.Log("hit!");
        }
    }

    IEnumerator WaitThenTurn()
    {
        CanMove = false;
        yield return new WaitForSeconds(5);
        CanMove = true;

        MoveRight = !MoveRight;
    }
}
