using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallAnswer : MonoBehaviour
{
    public int answerValue; // 存储这个球代表的答案
    private MathQuestionGenerator mathQuestionGenerator;
    public TextMeshPro textMesh; // 小球上显示数字的TextMeshPro组件

    void Start()
    {
        // 找到MathQuestionGenerator的引用
        mathQuestionGenerator = FindObjectOfType<MathQuestionGenerator>();
    }

    public void SetAnswer(int value)
    {
        answerValue = value;
        // 更新小球上的显示数字
        if (textMesh != null)
        {
            textMesh.text = value.ToString();
        }
    }

    void OnMouseDown()
    {
        // 当小球被点击时，调用MathQuestionGenerator的CheckAnswer方法
        mathQuestionGenerator.CheckAnswer(answerValue);
    }
}
