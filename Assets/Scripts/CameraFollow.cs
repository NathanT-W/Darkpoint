using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform playerTransform;

   void Start()
   {
		  playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
   }

   void Update()
   {
		if (playerTransform != null)
		{
			transform.position = playerTransform.position + new Vector3(0,10,-10);
		}
   }
}
