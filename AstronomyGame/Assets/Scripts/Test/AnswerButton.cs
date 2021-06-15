using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Test Test;
    public bool IsCorrect;
    public Question Question;

    public void OnAnswerButtonDown()
    {
        if (IsCorrect)
        {
            Test.Score++;
            Test.RightAnswers.Add(Question);
        }
        else
            Test.WrongAnswers.Add(Question);
        Test.CurrentQuestionNumber++;
        Test.GetNextQuestion();
    }
}
