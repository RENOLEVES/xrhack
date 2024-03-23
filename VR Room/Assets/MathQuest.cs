using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro; // 引入TextMeshPro的命名空间

public class MathQuest : MonoBehaviour
{
    public TextMeshPro questionTextMesh; // 用于显示问题的TextMeshPro对象
    public TextMeshPro scoreTextMesh; // 用于显示得分的TextMeshPro对象
    private int answer; // 当前问题的正确答案
    private int score = 0; // 玩家的得分

    void Start()
    {
        if (questionTextMesh == null || scoreTextMesh == null)
        {
            Debug.LogError("TextMesh references are not set.");
            return;
        }

        GenerateNewQuestion();
        UpdateScoreDisplay();
    }

    void GenerateNewQuestion()
    {
        int a = Random.Range(1, 10); // 生成第一个随机数
        int b = Random.Range(1, 10); // 生成第二个随机数
        int operation = Random.Range(0, 4); // 随机选择加、减、乘、除

        switch (operation)
        {
            case 0: // 加法
                answer = a + b;
                questionTextMesh.text = $"{a} + {b} = ?";
                break;
            case 1: // 减法
                answer = a - b;
                questionTextMesh.text = $"{a} - {b} = ?";
                break;
            case 2: // 乘法
                answer = a * b;
                questionTextMesh.text = $"{a} * {b} = ?";
                break;
            case 3: // 除法
                b = Random.Range(1, a + 1); // 确保除数不为0，并且能整除
                a = b * Random.Range(1, 10); // 确保结果是整数
                answer = a / b;
                questionTextMesh.text = $"{a} / {b} = ?";
                break;
        }
    }

    public void CheckAnswer(int playerAnswer)
    {
        if (playerAnswer == answer)
        {
            Debug.Log("Correct Answer!");
            score++; // 答对加一分
        }
        else
        {
            Debug.Log("Wrong Answer.");
            score--; // 答错减一分
        }

        UpdateScoreDisplay(); // 更新得分显示
        GenerateNewQuestion(); // 生成新问题
    }

    void UpdateScoreDisplay()
    {
        // 更新得分显示
        scoreTextMesh.text = "Score: " + score;
    }
}
