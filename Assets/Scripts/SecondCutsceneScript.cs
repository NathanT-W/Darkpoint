using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SecondCutsceneScript : MonoBehaviour
{

    public GameObject cutsceneVan, Van, cutsceneAva, Ava, mainCamera;
    public PlayableDirector cutsceneStarter, cutsceneEnder;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.GetComponent<CameraFollow>().enabled = false;

        Van = GameObject.FindGameObjectWithTag("Player");
        Ava = GameObject.FindGameObjectWithTag("Fairy");

        Van.SetActive(false);
        Ava.SetActive(false);

        cutsceneStarter.Play();
    }

    void Update()
    {

        if (cutsceneVan.GetComponent<PlayerCutsceneView>().cutsceneDone && cutsceneAva.GetComponent<PlayerCutsceneView>().cutsceneDone)
        {
            Van.SetActive(true);
            Ava.SetActive(true);

            Van.transform.position = cutsceneVan.transform.position;
            Ava.transform.position = cutsceneAva.transform.position;

            mainCamera.GetComponent<CameraFollow>().enabled = true;

            cutsceneEnder.Play();

            cutsceneVan.GetComponent<PlayerCutsceneView>().cutsceneDone = false;
            cutsceneAva.GetComponent<PlayerCutsceneView>().cutsceneDone = false;

        }
    }
}
