using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text CurrentQuestion;
    public List<GameObject> CurrentAnswers;

    public List<Question> Questions;

    public List<Question> RightAnswers;
    public List<Question> WrongAnswers;
    public Text RightAnswersText;
    public Text WrongAnswersText;

    public Canvas Answers;

    public int CurrentQuestionNumber;
    public int MaxQuestionCount;
    public int Score;
    public int ScoreForEnd;
    public Text ResultText;
    public Text EndButton;

    private int SceneToLoad;

    private void Start()
    {
        Answers.enabled = false;
        SceneToLoad = 1;
        ResultText.enabled = false;
        EndButton.enabled = false;
        GetNextQuestion();
    }

    public void GetNextQuestion()
    {
        if (CurrentQuestionNumber == MaxQuestionCount)
        {
            ResultText.enabled = true;
            CurrentQuestion.enabled = false;
            CurrentAnswers.ForEach(x => x.GetComponent<Text>().enabled = false);
            if (Score < ScoreForEnd)
            {
                ResultText.text = "Вы ответили правильно на следующее количество вопросов: \n" + Score + ". \nПройдите тест еще раз.";
                EndButton.text = "ПОСМОТРЕТЬ ОШИБКИ";
                EndButton.enabled = true;
            }
            else
            {
                ResultText.text = "Вы ответили правильно на следующее количество вопросов: \n" + Score + ". \nТеперь для вас доступна следующая миссия!";
                EndButton.text = "ПОСМОТРЕТЬ ОШИБКИ";
                EndButton.enabled = true;
            }
            return;
        }
        CurrentQuestion.text = Questions[CurrentQuestionNumber].Text;
        for (var i = 0; i < Questions[CurrentQuestionNumber].Answers.Count; i++)
        {
            var AnswerText = CurrentAnswers[i].GetComponent<Text>();
            var AnswerButton = CurrentAnswers[i].GetComponent<AnswerButton>();
            AnswerText.text = Questions[CurrentQuestionNumber].Answers[i].Text;
            AnswerButton.IsCorrect = Questions[CurrentQuestionNumber].Answers[i].IsCorrect;
            AnswerButton.Question = 
                new Question { Text = CurrentQuestion.text, Answers = new List<Answer>() { new Answer { Text = AnswerText.text, IsCorrect = AnswerButton.IsCorrect } } };
        }
    }

    public void OnEndButtonDown()
    {
        if (!Answers.enabled)
        {
            ResultText.enabled = false;
            EndButton.text = Score < ScoreForEnd ? "ПРОЙТИ ТЕСТ ЕЩЕ РАЗ" : "ЗАКОНЧИТЬ ТЕСТ";
            ShowAnsweredQuestions();
        }
        else if (Score < ScoreForEnd)
            Restart();
        else
            EndTest();
    }

    public void Restart()
    {
        Score = 0;
        CurrentQuestionNumber = 0;
        ResultText.enabled = false;
        EndButton.enabled = false;
        Answers.enabled = false;
        CurrentQuestion.enabled = true;
        CurrentAnswers.ForEach(x => x.GetComponent<Text>().enabled = true);
        GetNextQuestion();
    }

    public void ShowAnsweredQuestions()
    {
        Answers.enabled = true;
        foreach (var question in RightAnswers)
        {
            
            RightAnswersText.text = RightAnswersText.text + question.Text + '\n' + question.Answers[0].Text + "\n\n";
        }
        foreach (var question in WrongAnswers)
        {

            WrongAnswersText.text = WrongAnswersText.text + question.Text + '\n' + question.Answers[0].Text + "\n\n";
        }
    }

    public void EndTest()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
