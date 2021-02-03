using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LevelTravel : MonoBehaviour
{
    private bool VanReadyToLeave;
    private bool AvaReadyToLeave;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            VanReadyToLeave = true;
        if (collision.name == "2ndPlayer")
            AvaReadyToLeave = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
            VanReadyToLeave = true;
        if (collision.name == "2ndPlayer")
            AvaReadyToLeave = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
            VanReadyToLeave = false;
        if (collision.name == "2ndPlayer")
            AvaReadyToLeave = false;
    }

    void Update()
    {
        if(VanReadyToLeave&&AvaReadyToLeave)
        {
            PhotonNetwork.LoadLevel("Level2");
        }
    }
}
