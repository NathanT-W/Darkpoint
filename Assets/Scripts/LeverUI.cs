using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LeverUI : MonoBehaviour
{
    public GameObject lever;
    public GameObject button;
    public GameObject interactingPlayer;
    private GUIStyle labelSize = new GUIStyle();

    private void Start()
    {
        lever = GameObject.FindGameObjectWithTag("Lever");
        button = GameObject.FindGameObjectWithTag("Button");
        labelSize.fontSize = 25;
    }

    private void OnGUI()
    {
        if ((lever.GetComponent<LeverInteract>().interactable && lever.GetComponent<LeverInteract>().interacted == false && gameObject.GetPhotonView().IsMine) || (button.GetComponent<ButtonInteractionHandler>().interactable && button.GetComponent<ButtonInteractionHandler>().interacted == false && !gameObject.GetPhotonView().IsMine))
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 650, 300), "Press 'E' to Interact", labelSize);
        }
    }

}
