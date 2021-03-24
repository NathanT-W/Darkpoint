using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    public GameObject section1, section2, section3, section4;

    private void Awake()
    {
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();

        Debug.Log("Connecting to Photon...");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();

        Debug.Log("We are connected to master");
    }

    public override void OnJoinedLobby()
    {
        section1.SetActive(false);
        section2.SetActive(true);
        section4.SetActive(false);
        Debug.Log("Joined Lobby");
    }

    public void OnDisconnectedFromPhoton()
    {
        if(section1.activeSelf)
        {
            section1.SetActive(false);
        }
        if(section2.activeSelf)
        {
            section2.SetActive(false);
        }
        if (section4.activeSelf)
        {
            section4.SetActive(false);
        }

        section3.SetActive(true);

        Debug.Log("Disconnected from Photon Services");
    }

    public void OnConnectedToRoom()
    {
        section2.SetActive(false);
        section4.SetActive(true);
    }

}
