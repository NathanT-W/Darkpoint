using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LevelTravel1 : MonoBehaviour
{
    private bool VanReadyToLeave;
    private bool AvaReadyToLeave;

    private GameObject Van, Ava;

    public GameObject VanSpawnPoint2, AvaSpawnPoint2;

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

        if (VanReadyToLeave && AvaReadyToLeave && GameManager.currentLevel == 1 && this.name == "Level1TravelBox")
            TeleportLevel2();
            //StartCoroutine(TeleportLevel2());
    }

    void TeleportLevel2()
    {
        VanReadyToLeave = false;
        AvaReadyToLeave = false;

        //yield return new WaitForSeconds(1);

        Van.transform.position = VanSpawnPoint2.transform.position;
        Ava.transform.position = AvaSpawnPoint2.transform.position;

        GameManager.currentLevel = 2;

        Van.SetActive(false);
        Ava.SetActive(false);

        Camera.main.GetComponent<CameraFollow>().enabled = false;
        Camera.main.GetComponent<CutsceneEndScript>().secondLevelCutscenePlay();

        //StopCoroutine(TeleportLevel2());
    }
}