using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PhotonHandler: MonoBehaviourPunCallbacks
{
    public InputField createRoomInput, joinRoomInput;

    public PhotonButtons Buttons;

    public GameObject mainPlayer;

    public GameObject photonScripts;

    public Text roomName, player2Name;

    private string RoomName, PlayerName;

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
            }
        }
        photonScripts.GetComponent<PhotonConnect>().OnConnectedToRoom();
        roomName.text = RoomName;
        Debug.Log("Connected to the room: " + RoomName);

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);

        player2Name.text = newPlayer.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);

        player2Name.text = "";
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Level1")
        {
            SpawnPlayer();
        }
    }

    public void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(mainPlayer.name, mainPlayer.transform.position, mainPlayer.transform.rotation, 0); 
    }

    public void MoveScene()
    {
        Buttons = null;
        PhotonNetwork.LoadLevel("Level1");
    }

}
