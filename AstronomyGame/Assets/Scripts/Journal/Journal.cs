using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public Canvas Canvas;

    private void Start()
    {
        Canvas.enabled = false;
    }

    public void Interaction()
    {
        Canvas.enabled = !Canvas.enabled;
    }
}
