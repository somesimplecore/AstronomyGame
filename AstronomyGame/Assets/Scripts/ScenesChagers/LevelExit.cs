using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public bool IsPlayerNearby;
    public int SceneToLoad;

    public void Interaction(Player player)
    {
        if(player.CanEndLevel)
            SceneManager.LoadScene(SceneToLoad);
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
