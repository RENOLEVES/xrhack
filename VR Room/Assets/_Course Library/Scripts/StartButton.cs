using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartButton : MonoBehaviour
{
    // Event to signal when the game should start
    public UnityEvent onStartGame;

    // Reference to the StartTextController
    public StartTextController startTextController;

    // Method to handle user interaction with the control button
    private void OnMouseDown()
    {
        // Check if the onStartGame event is assigned any listeners
        if (onStartGame != null)
        {
            // Invoke the onStartGame event, signaling that the game should start
            onStartGame.Invoke();

            // Hide the start text
            startTextController.HideText();
        }
    }
}
