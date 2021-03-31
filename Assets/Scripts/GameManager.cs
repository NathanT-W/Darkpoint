using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currentLevel;

    public GameObject CogCounter;

    private void Start()
    {
        currentLevel = 1;
    }

    private void Update()
    {
        if(currentLevel == 3)
        {
            CogCounter.SetActive(true);
        }
    }
}
