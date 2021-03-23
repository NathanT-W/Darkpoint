using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LeverUI : MonoBehaviour
{
    public GameObject lever;

    private void Start()
    {
        lever = GameObject.FindGameObjectWithTag("Lever");
    }

    private void OnGUI()
    {
        if (lever.GetComponent<LeverInteract>().interactable && lever.GetComponent<LeverInteract>().interacted == false && gameObject.GetComponent<PhotonView>().IsMine)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 650, 300), "Press 'E' to Interact");
        }
    }

}
