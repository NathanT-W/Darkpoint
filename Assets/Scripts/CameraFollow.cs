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
			transform.position = playerTransform.position + new Vector3(0,35,-10);

			if (transform.position.x < -115)
				transform.SetPositionAndRotation(new Vector3(-115, transform.position.y, transform.position.z), transform.rotation);

			if (transform.position.x > 45)
				transform.SetPositionAndRotation(new Vector3(45, transform.position.y, transform.position.z), transform.rotation);

			if (transform.position.y > 32)
				transform.SetPositionAndRotation(new Vector3(transform.position.x, 32, transform.position.z), transform.rotation);
		}
   }
}
