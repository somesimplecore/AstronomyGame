using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestTextManager : MonoBehaviour
{
    public Text QuestText;
    public Text NameText;

    public Animator BoxAnimator;
    public Animator StartAnimator;

    public Queue<string> Sentences;

    void Start()
    {
        Sentences = new Queue<string>();
    }

    public void StartQuestText(QuestText questText)
    {
        BoxAnimator.SetBool("StartOpen", true);
        StartAnimator.SetBool("StartOpen", false);

        Sentences.Clear();

        foreach (var sentence in questText.sentences)
            Sentences.Enqueue(sentence);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (Sentences.Count == 0)
        {
            EndQuestText();
            return;
        }
        var sentence = Sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        QuestText.text = "";
        foreach(var letter in sentence)
        {
            QuestText.text += letter;
            yield return null;
        }
    }

    public void EndQuestText()
    {
        BoxAnimator.SetBool("StartOpen", false);
    }
}
