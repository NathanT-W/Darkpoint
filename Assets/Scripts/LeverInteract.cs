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
    public PhotonView photonView;

    bool interactable = false;

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
                print("test");
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
        interactable = false;
    }
}
