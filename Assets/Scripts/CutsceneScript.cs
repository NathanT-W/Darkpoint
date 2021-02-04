using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class CutsceneScript : MonoBehaviour
{

    public GameObject Van, Ava, flowchart;
    Vector3 endPoint;
    bool cutsceneBegin = false;


    private void Update()
    {
        Van = GameObject.FindGameObjectWithTag("Player");
        Van.GetComponentInChildren<Animator>().SetFloat("Speed", 10);
        endPoint = new Vector3(Van.transform.position.x + 110, Van.transform.position.y, Van.transform.position.z);
        if (!cutsceneBegin)
        {
            Van.transform.position = Vector3.Lerp(Van.transform.position, endPoint, 0.0005f);
        }

        if(Van.transform.position.x > -120.8)
        {
            cutsceneBegin = true;
            Van.GetComponentInChildren<Animator>().SetFloat("Speed", 0);
            Debug.Log("Help");
        }

        if (cutsceneBegin)
        {
            flowchart.SetActive(true);
        }

    }

    public void cutsceneEnd()
    {
        Ava = GameObject.FindGameObjectWithTag("Fairy");

        Van.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<CameraFollow>().enabled = true;
        Ava.GetComponent<FairyMovement>().enabled = true;
    }
}