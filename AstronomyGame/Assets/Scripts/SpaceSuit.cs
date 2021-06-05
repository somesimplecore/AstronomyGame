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

        var isFliped = player.CurrentSprite.flipX;
        player.CurrentSprite.enabled = false;
        player.CurrentSprite = player.CurrentSprite == player.SpriteWithoutSpaceSuit ? player.SpriteInSpaceSuit : player.SpriteWithoutSpaceSuit;
        player.CurrentSprite.enabled = true;
        player.CurrentSprite.flipX = isFliped;
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
