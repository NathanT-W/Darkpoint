using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector sceneToPlay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        sceneToPlay.Play();

        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        GameObject.FindGameObjectWithTag("Fairy").SetActive(false);

        gameObject.GetComponent<CutsceneTrigger>().enabled = false;
    }
}
