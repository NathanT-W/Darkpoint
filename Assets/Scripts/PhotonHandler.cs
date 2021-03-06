﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PhotonHandler: MonoBehaviourPunCallbacks
{
    public InputField createRoomInput, joinRoomInput;

    public PhotonButtons Buttons;

    public GameObject mainPlayer, clientPlayer, photonScripts, readyUpButton, unReadyUpButton, scrollView, roomListingPrefab;
    public GameObject VanSpawnPoint, AvaSpawnPoint;

    public Text roomName, player2Name;

    private string RoomName, PlayerName;

    private int noOfReadyPlayers;


    private void Awake()
    {
        DontDestroyOnLoad(this.transform);

        PhotonNetwork.SendRate = 30;

        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public void CreateRoom()
    {
        PlayerName = PhotonNetwork.NickName;
        RoomName = Buttons.createRoomInput.text;
        PhotonNetwork.CreateRoom(RoomName, new RoomOptions() { MaxPlayers = 2 }, null);
    }

    public void JoinOrCreateRoom()
    {
        PlayerName = PhotonNetwork.NickName;
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        RoomName = Buttons.joinRoomInput.text;
        PhotonNetwork.JoinOrCreateRoom(RoomName, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Player[] playerList = PhotonNetwork.PlayerList;

        foreach (Player p in playerList)
        {
            if (!p.NickName.Equals(PhotonNetwork.NickName))
            {
                player2Name.text = p.NickName;
                readyUpButton.SetActive(true);
            }
        }
        photonScripts.GetComponent<PhotonConnect>().OnConnectedToRoom();
        roomName.text = RoomName;
        Debug.Log("Connected to the room: " + RoomName);

    }

    void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("MainMenu");
    }

    public void disconnect()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("Disconnected from the room: " + RoomName);
    }

    [PunRPC]
    public void readyUp()
    {
        noOfReadyPlayers += 1;

        if(noOfReadyPlayers == 2)
        {
            MoveScene();
        }
    }

    [PunRPC]
    public void unReadyUp()
    {
        noOfReadyPlayers -= 1;
    }

    public void changeReadyUp()
    {

        if (readyUpButton.activeSelf)
        {
            readyUpButton.SetActive(false);
            unReadyUpButton.SetActive(true);
            photonView.RPC("readyUp", RpcTarget.All);
        }
        else
        {
            readyUpButton.SetActive(true);
            unReadyUpButton.SetActive(false);
            photonView.RPC("unReadyUp", RpcTarget.All);
        }

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);

        readyUpButton.SetActive(true);

        player2Name.text = newPlayer.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);

        readyUpButton.SetActive(false);

        noOfReadyPlayers -= 1;

        player2Name.text = "";
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Level1")
        {
            VanSpawnPoint = GameObject.Find("VanSpawnPoint1");
            AvaSpawnPoint = GameObject.Find("AvaSpawnPoint1");
        }
    }

    public void SpawnPlayer()
    {
        GameObject player;

        if (PhotonNetwork.IsMasterClient)
        player = PhotonNetwork.Instantiate(mainPlayer.name, VanSpawnPoint.transform.position, mainPlayer.transform.rotation, 0);
        else
        player = PhotonNetwork.Instantiate(clientPlayer.name, AvaSpawnPoint.transform.position, clientPlayer.transform.rotation, 0);

        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    public void MoveScene()
    {
        Buttons = null;
        PhotonNetwork.LoadLevel("Level1");
    }

    public void PopulateListView(List<RoomInfo> roomList)
    {
        float y = 0.15f;
        foreach (RoomInfo room in roomList)
        {
            if(room.PlayerCount < 2)
            {
                GameObject roomListing = GameObject.Instantiate(roomListingPrefab, scrollView.transform);
                roomListing.GetComponentInChildren<Text>().text = room.Name;
                roomListing.GetComponent<Button>().onClick.AddListener(delegate { ListJoinRoom(room.Name); });
              //  roomListing.transform.position += new Vector3(0, y, 0);
                y -= 0.65f;
            }

        }
    }

    public void ListJoinRoom(string roomName)
    {
        Buttons.joinRoomInput.text = roomName;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int children = scrollView.transform.childCount;
        if(children > 0)
        {
            for (int i = 0; i < children; i++)
            {
                GameObject.Destroy(scrollView.transform.GetChild(i).gameObject);
            }
        }

        PopulateListView(roomList);
    }

}
