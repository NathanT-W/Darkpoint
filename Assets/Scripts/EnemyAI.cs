using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 8;
    public bool MoveRight;
    public float randTime;
    public GameObject ResetSpawnPoint;

    void Start()
    {
        Invoke("ChangeDirection", 1);
        ResetSpawnPoint = GameObject.Find("VanSpawnPoint2");
    }

    void ChangeDirection()
    {
        float randTime = Random.Range(1, 10);

        MoveRight = !MoveRight;

        Invoke("ChangeDirection", randTime);
    }

    void Update()
    {
       if(MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(3, 3);
        }
       else
       {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-3, 3);
       }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.CompareTag("TurnRight"))
        {
            MoveRight = true;
        }
        else if(trigger.gameObject.CompareTag("TurnLeft"))
        {
            MoveRight = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            collider.transform.position = ResetSpawnPoint.transform.position;
            Debug.Log("hit!");
        }
    }
}
