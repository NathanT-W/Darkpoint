using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Photon.Pun;
using Photon.Realtime;
public class CutsceneScript : MonoBehaviour
{
    public GameObject cutsceneVan, Van, cutsceneAva, Ava, interactableLever, interactableButton, mainCamera;
    public PlayableDirector cutsceneEnder;
    public int cutsceneNum = 0;

    void Update()
    {

        if (cutsceneVan.GetComponent<PlayerCutsceneView>().cutsceneDone && cutsceneAva.GetComponent<PlayerCutsceneView>().cutsceneDone)
        {
            switch (cutsceneNum)
            {
                case 0: // Cutscene 1
                    GameObject photonObject = GameObject.Find("PhotonDontDestroy");
                    photonObject.GetComponent<PhotonHandler>().SpawnPlayer();

                    cutsceneEnder.Play();

                    cutsceneVan.GetComponent<PlayerCutsceneView>().cutsceneDone = false;
                    cutsceneAva.GetComponent<PlayerCutsceneView>().cutsceneDone = false;

                    if (PhotonNetwork.IsMasterClient)
                        interactableLever.SetActive(true);

                    gameObject.GetComponent<CameraFollow>().enabled = true;

                    break;
                case 1: // Cutscene 2
                    Van.SetActive(true);
                    Ava.SetActive(true);

                    Van.transform.position = cutsceneVan.transform.position;
                    Ava.transform.position = cutsceneAva.transform.position;

                    mainCamera.GetComponent<CameraFollow>().enabled = true;

                    cutsceneEnder.Play();

                    cutsceneVan.GetComponent<PlayerCutsceneView>().cutsceneDone = false;
                    cutsceneAva.GetComponent<PlayerCutsceneView>().cutsceneDone = false;

                    if (!PhotonNetwork.IsMasterClient)
                        interactableButton.SetActive(true);

                    break;
                case 2:
                case 3: 
                case 4:
                    Van.SetActive(true);
                    Ava.SetActive(true);

                    Van.transform.position = cutsceneVan.transform.position;
                    Ava.transform.position = cutsceneAva.transform.position;

                    mainCamera.GetComponent<CameraFollow>().enabled = true;

                    cutsceneEnder.Play();

                    cutsceneVan.GetComponent<PlayerCutsceneView>().cutsceneDone = false;
                    cutsceneAva.GetComponent<PlayerCutsceneView>().cutsceneDone = false;

                    break;
                default: // Cutscene Error
                    Debug.Log("error");
                    break;
            }

            cutsceneNum += 1;

            Debug.Log("Cutscene Ended");
        }
    }

    public void playCutscene(PlayableDirector cutsceneToPlay)
    {
        mainCamera.GetComponent<CameraFollow>().enabled = false;

        Van.SetActive(false);
        Ava.SetActive(false);

        cutsceneToPlay.Play();
    }

}