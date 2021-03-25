using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Photon.Pun;
using Photon.Realtime;

public class CutsceneEndScript : MonoBehaviour
{
    public GameObject Van, Ava, Milo;
    public PlayableDirector interlude;

    public void cutsceneEnd()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Van.GetComponent<PlayerCutsceneView>().setVariable();
        }
        else
        {
            Ava.GetComponent<PlayerCutsceneView>().setVariable();
        }

    }

    public void cutsceneInterlude()
    {
        interlude.Play();
    }
}
