using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Photon.Pun;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector sceneToPlay;

    public GameObject travelBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("Fairy")) && collision.gameObject.GetPhotonView().IsMine)
        {
            gameObject.GetPhotonView().RPC("activateCutscene", RpcTarget.All);
        }

    }

    [PunRPC]
    public void activateCutscene()
    {
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        Camera.main.GetComponent<CutsceneScript>().playCutscene(sceneToPlay);
        travelBox.SetActive(true);
        Destroy(this);
    }
}
