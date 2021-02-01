﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteract : MonoBehaviour
{

    public GameObject activatedSwitch;

    bool interactable = false;

    private void OnCollisionEnter2D(Collision2D collision)
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
            }
        }
    }
}
