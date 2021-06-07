using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator CloudAnimator;
    public DialogueManager QuestTextManager;
    public Dialogue Dialogue;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        CloudAnimator.SetBool("StartOpen", true);
        QuestTextManager.StartDialogue(Dialogue);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        CloudAnimator.SetBool("IsClosed", true);
        QuestTextManager.EndDialogue();
    }
}
