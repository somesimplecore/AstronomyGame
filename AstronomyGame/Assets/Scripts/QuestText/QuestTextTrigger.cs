using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTextTrigger : MonoBehaviour
{
    public QuestText QuestText;

    public void TriggerQuestTex()
    {
        FindObjectOfType<QuestTextManager>().StartQuestText(QuestText);
    }
}
