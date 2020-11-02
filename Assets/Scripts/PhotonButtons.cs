using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonButtons : MonoBehaviourPunCallbacks
{
    public PhotonHandler Handler;

    public InputField createRoomInput, joinRoomInput;

    public void onClickCreateRoom()
    {
        Handler.CreateRoom();
    }

    public void onClickJoinRoom()
    {
        Handler.JoinOrCreateRoom();
    } 

}
