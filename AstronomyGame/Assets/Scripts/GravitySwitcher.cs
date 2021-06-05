using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitcher : MonoBehaviour
{
    [SerializeField] public GameObject GameObject;
    [SerializeField] public float ForceWhenOff;
    [SerializeField] public float ForceWhenOn;
    [SerializeField] public float RigitBodyGravityScaelWhenOff;
    [SerializeField] public float RigitBodyGravityScaelWhenOn;
    [SerializeField] public SpriteRenderer SpriteWhenOff;
    [SerializeField] public SpriteRenderer SpriteWhenOn;

    public bool IsWorking;
    [SerializeField] public bool IsPlayerNearby;

    private void Start()
    {
        SpriteWhenOn.enabled = false;
    }

    public void Pool()
    {
        IsWorking = !IsWorking;
        SpriteWhenOff.enabled = !IsWorking;
        SpriteWhenOn.enabled = IsWorking;
    }
    public void SetForces(Player player)
    {
        player.JumpForce = IsWorking ? ForceWhenOn : ForceWhenOff;
        player.RigitBody.gravityScale = IsWorking ? RigitBodyGravityScaelWhenOff : RigitBodyGravityScaelWhenOn;
    }

    public void Interaction(Player player)
    {
        Pool();
        SetForces(player);
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
