using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathQuestionGenerator : MonoBehaviour
{
    public TextMeshPro questionTextMesh; 
    public TextMeshPro scoreTextMesh;
    private int answer;
    private int score = 0; 

    void Start()
    {
        GenerateNewQuestion();
        UpdateScoreDisplay();
    }

    void GenerateNewQuestion()
    {
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10); 
        int operation = Random.Range(0, 4); 

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
                // 确保不会出现除以0的情况
                b = (b == 0) ? 1 : b;
                // 保证结果为整数
                a = a * b;
                answer = a / b;
                questionTextMesh.text = $"{a} / {b} = ?";
                break;
        }
    }

    public void CheckAnswer(int playerAnswer)
    {
        if (playerAnswer == answer)
        {
            score++; // 答对得分
        }
        else
        {
            score--; // 答错扣分
        }
        UpdateScoreDisplay(); // 更新得分显示
        GenerateNewQuestion(); // 无论对错都生成新的问题
    }

    void UpdateScoreDisplay()
    {
        scoreTextMesh.text = "Score: " + score; // 更新得分文本
    }
}
