using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    public Text DialogueText;
    public Animator CloudAnimator;
    public Queue<string> Sentences;
    public Text NextButton;

    void Start()
    {
        Sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        NextButton.enabled = true;
        CloudAnimator.SetBool("StartOpen", true);
        CloudAnimator.SetBool("IsOpened", true);

        Sentences.Clear();

        foreach (var sentence in dialogue.Sentences)
            Sentences.Enqueue(sentence);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (Sentences.Count == 1)
            NextButton.enabled = false;
        if (Sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        var sentence = Sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogueText.text = "";
        foreach(var letter in sentence)
        {
            DialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        CloudAnimator.SetBool("StartClose", true);
        CloudAnimator.SetBool("IsClosed", true);
    }
}
