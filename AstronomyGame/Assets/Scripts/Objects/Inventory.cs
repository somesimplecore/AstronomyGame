using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Canvas Canvas;

    public bool[] IsFool;
    public GameObject[] Slots;

    void Start()
    {
        Canvas.enabled = false;
    }

    public void Interaction()
    {
        Canvas.enabled = !Canvas.enabled;
    }

    public void OnInventoryButton()
    {
        Interaction();
    }
}
