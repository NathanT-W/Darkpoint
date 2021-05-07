using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;

    public bool devTest;

    bool fairy = false;

    void Start()
    {
        GameObject Van = GameObject.FindGameObjectWithTag("Player");
        GameObject Ava = GameObject.FindGameObjectWithTag("Fairy");

        if (devTest)
        {
            playerTransform = Van.transform;
        }

        else if (Van != null)
        {
            if (Van.GetComponent<PhotonView>().IsMine)
                playerTransform = Van.transform;
        }
        else
        {
            playerTransform = Ava.transform;
            fairy = true;
        }

    }

    void Update()
    {
        if (playerTransform != null)
        {
            if (fairy)
                transform.position = playerTransform.position + new Vector3(0, 0, -10);
            else
                transform.position = playerTransform.position + new Vector3(0, 35, -10);

            if (devTest)
                return;

            switch (GameManager.currentLevel)
            {
                case 1:
                {
                    if (transform.position.x < -115)
                        transform.SetPositionAndRotation(new Vector3(-115, transform.position.y, transform.position.z), transform.rotation);
                    else if (transform.position.x > 45)
                        transform.SetPositionAndRotation(new Vector3(45, transform.position.y, transform.position.z), transform.rotation);

                    if (transform.position.y > 32)
                        transform.SetPositionAndRotation(new Vector3(transform.position.x, 32, transform.position.z), transform.rotation);
                    else if (transform.position.y < 8)
                        transform.SetPositionAndRotation(new Vector3(transform.position.x, 8, transform.position.z), transform.rotation);
                    break;
                }
                case 2:
                {
                    if (transform.position.x < -118)
                        transform.SetPositionAndRotation(new Vector3(-118, transform.position.y, transform.position.z), transform.rotation);
                    else if (transform.position.x > 128)
                        transform.SetPositionAndRotation(new Vector3(128, transform.position.y, transform.position.z), transform.rotation);

                    if (transform.position.y > -140)
                        transform.SetPositionAndRotation(new Vector3(transform.position.x, -140, transform.position.z), transform.rotation);
                    else if (transform.position.y < -161)
                        transform.SetPositionAndRotation(new Vector3(transform.position.x, -161, transform.position.z), transform.rotation);
                    break;
                }
                case 3:
                {
                    if (transform.position.x < -118)
                        transform.SetPositionAndRotation(new Vector3(-118, transform.position.y, transform.position.z), transform.rotation);
                    else if (transform.position.x > 134)
                        transform.SetPositionAndRotation(new Vector3(134, transform.position.y, transform.position.z), transform.rotation);

                    if (transform.position.y > -316)
                        transform.SetPositionAndRotation(new Vector3(transform.position.x, -316, transform.position.z), transform.rotation);
                    else if (transform.position.y < -350)
                        transform.SetPositionAndRotation(new Vector3(transform.position.x, -350, transform.position.z), transform.rotation);
                    break;
                }
            }
        }
    }
}
