using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSuit : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Sprite;

    public bool IsPlayerNearby;

    public void Interaction(Player player)
    {
        Sprite.enabled = !Sprite.enabled;

        player.IsInSpaceSuit = !player.IsInSpaceSuit;
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
