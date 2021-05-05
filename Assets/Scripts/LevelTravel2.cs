using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LevelTravel2 : MonoBehaviour
{

    private bool VanReadyToLeave;
    private bool AvaReadyToLeave;

    private GameObject Van, Ava;

    private GameObject VanSpawnPoint3, AvaSpawnPoint3;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            VanReadyToLeave = true;
        if (collision.gameObject.tag == "Fairy")
            AvaReadyToLeave = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            VanReadyToLeave = false;
        if (collision.gameObject.tag == "Fairy")
            AvaReadyToLeave = false;
    }

    void Update()
    {
        Van = GameObject.FindGameObjectWithTag("Player");
        Ava = GameObject.FindGameObjectWithTag("Fairy");

        VanSpawnPoint3 = GameObject.Find("VanSpawnPoint3");
        AvaSpawnPoint3 = GameObject.Find("AvaSpawnPoint3");

        if (VanReadyToLeave && AvaReadyToLeave && GameManager.currentLevel == 2 && this.name == "Level2TravelBox")
            TeleportLevel3();
            //StartCoroutine(TeleportLevel3());
    }



    void TeleportLevel3()
    {
        VanReadyToLeave = false;
        AvaReadyToLeave = false;

        //yield return new WaitForSeconds(1);

        Van.transform.position = VanSpawnPoint3.transform.position;
        Ava.transform.position = AvaSpawnPoint3.transform.position;

        GameManager.currentLevel = 3;

        //StopCoroutine(TeleportLevel3());
    }
}