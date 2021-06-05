using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestText 
{
    public string Name;
    [TextArea(1, 6)]
    public string[] sentences;
}
