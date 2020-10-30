using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraFollow : MonoBehaviour
{
	public Transform playerTransform;
	public PhotonView photonView;

   void Start()
   {
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject player in players)
        {
            {
				this.playerTransform = player.transform;
				break;
            }
        }
	}

   void Update()
   {
		if (playerTransform != null)
		{
			transform.position = playerTransform.position + new Vector3(0,10,-10);
		}
   }
}
