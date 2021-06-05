using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTextAnimator : MonoBehaviour
{
    public Animator StartAnimation;
    public QuestTextManager QuestTextManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        StartAnimation.SetBool("StartOpen", true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        StartAnimation.SetBool("StartOpen", false);
        QuestTextManager.EndQuestText();
    }
}
