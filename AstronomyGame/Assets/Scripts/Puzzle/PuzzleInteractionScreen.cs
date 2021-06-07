using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInteractionScreen : MonoBehaviour
{
    public bool IsPlayerNearby;
    public Canvas PuzzleCanvas;

    public void Interaction(Player player)
    {
        PuzzleCanvas.enabled = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsPlayerNearby = true;
            collision.GetComponent<Player>().IntersectedObj = gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            IsPlayerNearby = false;
    }
}
