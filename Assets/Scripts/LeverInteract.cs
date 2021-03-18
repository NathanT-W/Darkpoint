using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class LeverInteract : MonoBehaviour
{
    public GameObject activatedSwitch;

    public GameObject cageDoorClosed;
    public GameObject cageDoorOpen;
    public GameObject cageDoorCollider;

    public GameObject hatchDoorOpen;
    public GameObject hatchDoorClosed;
    public GameObject LevelTravelBox;

    public PhotonView photonView;

    public bool interactable = false;
    public bool interacted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        photonView = (PhotonView) gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                photonView.RPC("openCage", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    void openCage()
    {
        activatedSwitch.SetActive(true);

        cageDoorClosed.SetActive(false);
        cageDoorOpen.SetActive(true);
        cageDoorCollider.SetActive(false);

        //hatchDoorOpen.SetActive(true);
        //hatchDoorClosed.SetActive(false);

        //LevelTravelBox.SetActive(true);

        interacted = true;

        gameObject.GetComponent<SecondCutsceneScript>().enabled = true;
    }
}
