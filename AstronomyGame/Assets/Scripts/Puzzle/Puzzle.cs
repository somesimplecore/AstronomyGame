using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Puzzle : MonoBehaviour
{
    public bool IsSolved;
    public int ConnectionsToSolve;
    public int CurrentConnection;
    public Canvas Canvas;
    public List<Star> SelectedStars = new List<Star>();

    private void Start()
    {
        Canvas.enabled = false;
    }

    private void Update()
    {
        if (CurrentConnection == ConnectionsToSolve && Canvas.enabled)
        {
            IsSolved = true;
            Canvas.enabled = false;
        }
        if (SelectedStars.Count == 2)
        {
            if (IsContainsSameConnection() && SelectedStars[0].IsSelected && SelectedStars[1].IsSelected)
            {
                CurrentConnection++;
                ConnectSelectedStars();
            }
            else
                UnselectStars();
        }
    }

    private void ConnectSelectedStars()
    {
        var connection = SelectedStars[0].Connections.Where(x => SelectedStars[1].Connections.Any(y => x == y)).FirstOrDefault();
        connection.Show();
        SelectedStars[0].CurrentConnections.Add(connection);
        SelectedStars[1].CurrentConnections.Add(connection);
        //StopAllCoroutines();
        //StartCoroutine(TimeDelay());
        SelectedStars[0].Unhighlight();
        SelectedStars[1].Unhighlight();
        SelectedStars[0].IsSelected = false;
        SelectedStars[1].IsSelected = false;
        SelectedStars.Clear();
    }

    private void UnselectStars()
    {
        SelectedStars[0].Unhighlight();
        SelectedStars[1].Unhighlight();
        SelectedStars[0].IsSelected = false;
        SelectedStars[1].IsSelected = false;
        SelectedStars.Clear();
    }

    IEnumerable TimeDelay()
    {
        yield return new WaitForSeconds(1);
    }

    public bool IsContainsSameConnection()
    {
        return SelectedStars[0].Connections.Any(x => SelectedStars[1].Connections.Any(y => x == y));
    }

    public bool IsStarCanBeSelected()
    {
        return SelectedStars.Count < 2;
    }
}
