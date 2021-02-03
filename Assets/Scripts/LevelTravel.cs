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
            PhotonNetwork.LoadLevel("Level2");
        }
    }
}
