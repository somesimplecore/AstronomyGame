using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public bool IsPlayerNearby;
    public List<GameObject> Items;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interaction(Player player)
    {
        for (var i = 0; i < player.Inventory.Slots.Length; i++)
        {
            if (Items.Count == 0)
                break;
            if (!player.Inventory.IsFool[i])
            {
                player.Inventory.IsFool[i] = true;
                Instantiate(Items[0], player.Inventory.Slots[i].transform);
                Items.RemoveAt(0);
            }
        }
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
