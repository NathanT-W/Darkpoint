using UnityEngine;
using Photon.Pun;

public class ButtonInteractionHandler : MonoBehaviour
{
    public GameObject buttonNotPressed;
    public GameObject buttonPressed;
    public GameObject hatchOpen;
    public GameObject hatchClosed;
    public GameObject LevelTravelBox;
    public GameObject interactableButton;

    PhotonView photonView;

    public bool interactable = false;
    public bool interacted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        interactable = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        interactable = false;
    }

    void Start()
    {
        photonView = gameObject.GetComponent<PhotonView>();
    }

    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                photonView.RPC("openHatch", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    void openHatch()
    {
        buttonNotPressed.SetActive(false);
        interactableButton.SetActive(false);
        buttonPressed.SetActive(true);

        hatchClosed.SetActive(false);
        hatchOpen.SetActive(true);

        LevelTravelBox.SetActive(true);

        interactable = false;
        interacted = true;
    }
}