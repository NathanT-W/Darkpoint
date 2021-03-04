using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LevelTravel : MonoBehaviour
{
    private bool VanReadyToLeave;
    private bool AvaReadyToLeave;

    public GameObject Van, Ava, VanSpawnPoint2, AvaSpawnPoint2;

    void Start()
    {
        Van = GameObject.Find("Player(Clone)");
        Ava = GameObject.Find("2ndPlayer(Clone)");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player(Clone)")
            VanReadyToLeave = true;
        if (collision.gameObject.name == "2ndPlayer(Clone)")
            AvaReadyToLeave = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player(Clone)")
            VanReadyToLeave = true;
        if (collision.name == "2ndPlayer(Clone)")
            AvaReadyToLeave = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player(Clone)")
            VanReadyToLeave = false;
        if (collision.name == "2ndPlayer(Clone)")
            AvaReadyToLeave = false;
    }

    void Update()
    {
        if(VanReadyToLeave&&AvaReadyToLeave)
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        Van.transform.position = VanSpawnPoint2.transform.position;
        yield return new WaitForSeconds(1);
        Ava.transform.position = AvaSpawnPoint2.transform.position;
    }
}