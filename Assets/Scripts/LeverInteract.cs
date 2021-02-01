using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteract : MonoBehaviour
{

    public GameObject activatedSwitch;
    public GameObject cageDoorClosed;
    public GameObject cageDoorOpen;

    bool interactable = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                activatedSwitch.SetActive(true);
                cageDoorClosed.SetActive(false);
                cageDoorOpen.SetActive(true);
            }
        }
    }
}
