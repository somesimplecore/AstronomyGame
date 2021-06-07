using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connection : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.GetComponent<Image>().enabled = false;
    }

    public void Show()
    {
        this.gameObject.GetComponent<Image>().enabled = true;
    }
}
