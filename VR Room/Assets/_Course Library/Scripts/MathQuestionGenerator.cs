using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathQuestionGenerator : MonoBehaviour
{
    public TextMeshPro questionTextMesh;
    public TextMeshPro scoreTextMesh;
    public int maxQuestions = 10;
    private int answer;
    private int score = 0;
    private int questionCount = 0;
    private Coroutine questionTimer;

    void Start()
    {
        GenerateNewQuestion();
        UpdateScoreDisplay();
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
        switch (operation)
        {
            case 0:
                answer = a + b;
                questionTextMesh.text = $"{a} + {b} = ?";
                break;
            case 1:
                answer = a - b;
                questionTextMesh.text = $"{a} - {b} = ?";
                break;
            case 2:
                answer = a * b;
                questionTextMesh.text = $"{a} * {b} = ?";
                break;
            case 3:
                b = (b == 0) ? 1 : b;
                a *= b;
                answer = a / b;
                questionTextMesh.text = $"{a} / {b} = ?";
                break;
        }

        questionCount++;
        ResetTimer();
    }

    public void CheckAnswer(int playerAnswer)
    {
        StopTimer();

        if (playerAnswer == answer)
        {
            score++;
        }
        else
        {
            score--;
        }

        UpdateScoreDisplay();
        GenerateNewQuestion();
    }

    void UpdateScoreDisplay()
    {
        scoreTextMesh.text = "Score: " + score;
    }

    void ResetTimer()
    {
        if (questionTimer != null)
        {
            StopCoroutine(questionTimer);
        }

        // 设定一个随机的回答时间
        float randomAnswerTime = Random.Range(5f, 15f); // 例如，5到15秒之间
        questionTimer = StartCoroutine(QuestionTimer(randomAnswerTime));
    }

    IEnumerator QuestionTimer(float time)
    {
        yield return new WaitForSeconds(time);
        CheckAnswer(-1); // 如果时间耗尽，自动将答案记为错误
    }

    void StopTimer()
    {
        if (questionTimer != null)
        {
            StopCoroutine(questionTimer);
            questionTimer = null;
        }
    }

    void EndGame()
    {
        StopTimer();
        questionTextMesh.text = "Game Over";
        scoreTextMesh.text += " - Final Score: " + score;

        // 可以添加其他游戏结束的逻辑，例如显示重新开始的按钮等
    }
}
