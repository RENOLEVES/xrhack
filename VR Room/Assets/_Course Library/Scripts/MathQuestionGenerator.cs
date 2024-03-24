using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathQuestionGenerator : MonoBehaviour
{
    public TextMeshPro questionTextMesh; // Text mesh to display the question
    public TextMeshPro scoreTextMesh; // Text mesh to display the score
    public GameObject ballPrefab; // The prefab for the balls
    public float radius = 5f; // Radius of the circle
    public int maxQuestions = 10; // Maximum number of questions to ask
    private int answer;
    private int score = 0;
    private int questionCount = 0;
    private Coroutine questionTimerCoroutine;
    private List<GameObject> currentBalls = new List<GameObject>(); // Store current balls

    void Start()
    {
        GenerateNewQuestion();
    }

    void GenerateNewQuestion()
    {
        if (questionCount >= maxQuestions)
        {
            EndGame();
            return;
        }

        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        int operation = Random.Range(0, 4);

        // Determine operation and calculate answer
        switch (operation)
        {
            case 0: // Addition
                answer = a + b;
                questionTextMesh.text = $"{a} + {b} = ?";
                break;
            case 1: // Subtraction
                answer = a - b;
                questionTextMesh.text = $"{a} - {b} = ?";
                break;
            case 2: // Multiplication
                answer = a * b;
                questionTextMesh.text = $"{a} * {b} = ?";
                break;
            case 3: // Division
                b = b == 0 ? 1 : b; // Ensure no division by zero
                a *= b; // Ensure the division result is an integer
                answer = a / b;
                questionTextMesh.text = $"{a} / {b} = ?";
                break;
        }

        // Update UI
        questionCount++;
        UpdateScoreDisplay();

        // Handle balls
        ClearBalls();
        GenerateBalls(answer);
        StartQuestionTimer();
    }

    // Update the score display
    void UpdateScoreDisplay()
    {
        scoreTextMesh.text = "Score: " + score;
    }

    // Start the question timer
    void StartQuestionTimer()
    {
        questionTimerCoroutine = StartCoroutine(QuestionTimer(10f)); // Set question time limit here
    }

    // Question timer coroutine
    IEnumerator QuestionTimer(float time)
    {
        yield return new WaitForSeconds(time);
        CheckAnswer(-1); // Incorrect answer if time runs out
    }

    // Check the answer
    public void CheckAnswer(int playerAnswer)
    {
        StopCoroutine(questionTimerCoroutine); // Stop the timer

        if (playerAnswer == answer)
        {
            score++;
        }
        else
        {
            score--;
        }

        // Generate a new question
        GenerateNewQuestion();
    }

    // Clear previous balls
    void ClearBalls()
    {
        foreach (GameObject ball in currentBalls)
        {
            Destroy(ball);
        }
        currentBalls.Clear();
    }

    // Generate balls with answers
    void GenerateBalls(int correctAnswer)
    {
        bool correctAnswerPlaced = false;

        for (int i = 0; i < 10; i++)
        {
            // Calculate the angle to place the ball
            float angle = i * Mathf.PI * 2 / 10;
            Vector3 ballPosition = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * radius;
            ballPosition += transform.position; // Center of the large sphere

            // Instantiate the ball
            GameObject ball = Instantiate(ballPrefab, ballPosition, Quaternion.identity, transform);
            BallAnswer ballAnswer = ball.GetComponent<BallAnswer>();

            // Assign an answer to the ball
            int answerValue = correctAnswerPlaced ? Random.Range(1, 100) : correctAnswer;
            ballAnswer.SetAnswer(answerValue);
            currentBalls.Add(ball);

            if (answerValue == correctAnswer) correctAnswerPlaced = true;
        }

        // Ensure there is a ball with the correct answer
        if (!correctAnswerPlaced)
        {
            currentBalls[currentBalls.Count - 1].GetComponent<BallAnswer>().SetAnswer(correctAnswer);
        }
    }

    // End the game
    void EndGame()
    {
        StopCoroutine(questionTimerCoroutine); // Stop the timer
        ClearBalls(); // Clear balls
        questionTextMesh.text = "Game Over";
        scoreTextMesh.text += " - Final Score: " + score;
        // Other game over logic...
    }
}
