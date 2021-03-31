using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CogCounter : MonoBehaviour
{
    public static int cogsCollected = 0;

    public Text cogText;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(cogsCollected);
        }

        cogText.text = cogsCollected.ToString();
    }

    public void Increment()
    {
        cogsCollected++;
    }

}
