using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public bool IsSelected;
    public Puzzle Puzzle;
    public GameObject SelectedCircle;
    public List<Connection> Connections = new List<Connection>();
    public List<Connection> CurrentConnections = new List<Connection>();

    private void Start()
    {
        
    }

    public void Select()
    {
        if (Puzzle.IsStarCanBeSelected() && !IsSelected && Connections.Count != CurrentConnections.Count)
        {
            IsSelected = true;
            Puzzle.SelectedStars.Add(this);
            Highlight();
        }
        else if (IsSelected)
        {
            IsSelected = false;
            Puzzle.SelectedStars.Remove(this);
            Unhighlight();
        }
    }

    public void Highlight()
    {
        Instantiate(SelectedCircle, this.transform);
    }

    public void Unhighlight()
    {
        foreach (Transform child in transform)
            GameObject.Destroy(child.gameObject);
    }
}
