using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour
{
    public int number; // Number associated with this ball

    public void OnPointerClick()
    {
        // Handle click event
        Debug.Log("Clicked on ball with number: " + number);

        // Add your logic for checking if this is the correct answer and providing feedback to the user
    }
}

