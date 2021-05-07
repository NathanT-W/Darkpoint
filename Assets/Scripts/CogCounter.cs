using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class CogCounter : MonoBehaviour
{
    public static int cogsCollected = 0;

    public Text cogText;

    public GameObject cutsceneTrigger;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(cogsCollected);
        }

        if (cogsCollected >= 5) {

            gameObject.GetPhotonView().RPC("SetTo5", RpcTarget.AllViaServer);
       
        }

        cogText.text = cogsCollected.ToString();
    }

    public void Increment()
    {
        cogsCollected++;
    }

    [PunRPC]

    public void SetTo5() {

        cogsCollected = 5;
        cutsceneTrigger.SetActive(true);

    }

}
