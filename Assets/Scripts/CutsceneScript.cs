using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Photon.Pun;
using Photon.Realtime;
public class CutsceneScript : MonoBehaviour
{
    public GameObject Van, Ava;
    public PlayableDirector cutsceneEnder;

    void Update()
    {

        if (Van.GetComponent<PlayerCutsceneView>().cutsceneDone && Ava.GetComponent<PlayerCutsceneView>().cutsceneDone)
        {

            GameObject photonObject = GameObject.Find("PhotonDontDestroy");
            photonObject.GetComponent<PhotonHandler>().SpawnPlayer();

            gameObject.GetComponent<CutsceneScript>().enabled = false;

            gameObject.GetComponent<CameraFollow>().enabled = true;

            cutsceneEnder.Play();

            Van.GetComponent<PlayerCutsceneView>().cutsceneDone = false;
            Ava.GetComponent<PlayerCutsceneView>().cutsceneDone = false;
        }
    }
}