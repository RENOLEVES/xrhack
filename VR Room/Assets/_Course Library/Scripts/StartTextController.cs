using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTextController : MonoBehaviour
{
    // Reference to the text component
    private Text startText;

    void Start()
    {
        // Get reference to the text component
        startText = GetComponent<Text>();

        // Show the text at the beginning
        startText.enabled = true;
    }

    // Method to hide the text when the game starts
    public void HideText()
    {
        // Hide the text
        startText.enabled = false;
    }
}

