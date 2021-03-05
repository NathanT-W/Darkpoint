using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerCutsceneView : MonoBehaviour
{

    public bool cutsceneDone = false;
    public void setVariable()
    {
        PhotonView photonView = gameObject.GetPhotonView();

        photonView.RPC("setAllVariables", RpcTarget.All);

    }

    [PunRPC]
    public void setAllVariables()
    {
        cutsceneDone = true;
    }
}
