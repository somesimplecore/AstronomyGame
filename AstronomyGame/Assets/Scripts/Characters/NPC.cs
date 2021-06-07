using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public int QuestCount;
    public Player Player;
    public List<DialogueAnimator> QuestsDialogues;
    public QuestsChecker QuestCheker;
    public DialogueTrigger DialogueTrigger;
    public List<Dialogue> Dialogues;
    public DialogueManager DialogueManager;
    public int ÑurrentQuest;

    public NPC()
    {

    }

    void Start()
    {
        ÑurrentQuest = 0;
    }

   
    void Update()
    {
        if(ÑurrentQuest == QuestCheker.CurrentQuest - 1)
        {
            ÑurrentQuest++;
            TriggerNextQuest();
        }
    }

    public void TriggerNextQuest()
    {
        DialogueManager.StartDialogue(Dialogues[ÑurrentQuest - 1]);
    }

}
