using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Photon.Pun;
using Photon.Realtime;

public class LeverInteract : MonoBehaviour
{
    public GameObject activatedSwitch;
    public GameObject interactableLever;

    public GameObject cageDoorClosed;
    public GameObject cageDoorOpen;
    public GameObject cageDoorCollider;

    public GameObject hatchDoorOpen;
    public GameObject hatchDoorClosed;
    public GameObject LevelTravelBox;

    public PhotonView photonView;

    public bool interactable = false;
    public bool interacted = false;

    public PlayableDirector nextCutscene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = false;
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
        activatedSwitch.SetActive(false);
        interactableLever.SetActive(false);

        cageDoorClosed.SetActive(false);
        cageDoorOpen.SetActive(true);
        cageDoorCollider.SetActive(false);

        //hatchDoorOpen.SetActive(true);
        //hatchDoorClosed.SetActive(false);

        //LevelTravelBox.SetActive(true);

        interacted = true;

        Camera.main.GetComponent<CutsceneScript>().Van = GameObject.FindGameObjectWithTag("Player");
        Camera.main.GetComponent<CutsceneScript>().Ava = GameObject.FindGameObjectWithTag("Fairy");
        Camera.main.GetComponent<CutsceneScript>().playCutscene(nextCutscene);
    }
}
