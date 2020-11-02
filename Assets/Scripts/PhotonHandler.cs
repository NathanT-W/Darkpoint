using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PhotonHandler: MonoBehaviourPunCallbacks
{
    public InputField createRoomInput, joinRoomInput;

    public PhotonButtons Buttons;

    public GameObject mainPlayer;

    private void Awake()
    {
        DontDestroyOnLoad(this.transform);

        PhotonNetwork.SendRate = 30;

        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(Buttons.createRoomInput.text, new RoomOptions() { MaxPlayers = 2 }, null);
    }

    public void JoinOrCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(Buttons.joinRoomInput.text, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        MoveScene();
        Debug.Log("Connected to the room");
        
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
