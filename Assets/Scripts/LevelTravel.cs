using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LevelTravel : MonoBehaviour
{
    private bool VanReadyToLeave;
    private bool AvaReadyToLeave;

    private GameObject Van, Ava, VanSpawnPoint2, AvaSpawnPoint2, VanSpawnPoint3, AvaSpawnPoint3;

    void Start()
    {
        Van = GameObject.FindGameObjectWithTag("Player");
        Ava = GameObject.FindGameObjectWithTag("Fairy");

        VanSpawnPoint2 = GameObject.Find("VanSpawnPoint2");
        AvaSpawnPoint2 = GameObject.Find("AvaSpawnPoint2");

        VanSpawnPoint3 = GameObject.Find("VanSpawnPoint3");
        AvaSpawnPoint3 = GameObject.Find("AvaSpawnPoint3");
    }

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
        if(VanReadyToLeave && AvaReadyToLeave && GameManager.currentLevel == 1)
            StartCoroutine(TeleportLevel2());

        if (VanReadyToLeave && AvaReadyToLeave && GameManager.currentLevel == 2)
            StartCoroutine(TeleportLevel3());
    }

    IEnumerator TeleportLevel2()
    {
        VanReadyToLeave = false;
        AvaReadyToLeave = false;

        Van.transform.position = VanSpawnPoint2.transform.position;
        yield return new WaitForSeconds(1);
        Ava.transform.position = AvaSpawnPoint2.transform.position;

        GameManager.currentLevel = 2;

        Van.SetActive(false);
        Ava.SetActive(false);

        Camera.main.GetComponent<CameraFollow>().enabled = false;
        Camera.main.GetComponent<CutsceneEndScript>().secondLevelCutscenePlay();
    }
    IEnumerator TeleportLevel3()
    {
        VanReadyToLeave = false;
        AvaReadyToLeave = false;

        Van.transform.position = VanSpawnPoint3.transform.position;
        yield return new WaitForSeconds(1);
        Ava.transform.position = AvaSpawnPoint3.transform.position;

        GameManager.currentLevel = 3;
    }
}