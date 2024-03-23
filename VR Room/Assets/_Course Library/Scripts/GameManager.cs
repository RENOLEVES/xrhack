using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Reference to your StartButton GameObject
    public StartButton startButton;

    void Start()
    {
        // Listen for the onStartGame event from the StartButton
        startButton.onStartGame.AddListener(StartGame);
    }

    // Method to start the game
    void StartGame()
    {
        Debug.Log("Game started!");
        // Add your game initialization logic here
    }
}

