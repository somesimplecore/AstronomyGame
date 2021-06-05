using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float Speed = 3;
    [SerializeField] public float JumpForce = 5;
    [SerializeField] public Inventory Inventory;


    public Rigidbody2D RigitBody;
    public SpriteRenderer CurrentSprite;
    public SpriteRenderer SpriteWithoutSpaceSuit;
    public SpriteRenderer SpriteInSpaceSuit;
    private bool IsGrounded;

    private float DirectionValue = 0;

    [SerializeField] public GameObject IntersectedObj;


    private void Start()
    {
        SpriteInSpaceSuit.enabled = false;
        SpriteInSpaceSuit.enabled = false;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        Run();
    }

    private void Run()
    {
        RigitBody.velocity = new Vector2(DirectionValue * Speed, RigitBody.velocity.y);
    }

    public void OnLeftButtonDown()
    {
        DirectionValue = -1;
        CurrentSprite.flipX = true;
    }

    public void OnRightButtonDown()
    {
        DirectionValue = 1;
        CurrentSprite.flipX = false;
    }

    public void OnButtonUp()
    {
        DirectionValue = 0;
    }

    private void Jump()
    {
        RigitBody.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
    }

    public void OnJumpButton()
    {
        if (IsGrounded)
            Jump();
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 5.2f);
        IsGrounded = collider.Length > 1;
    }

    private void DoSmthIfSomeObjectNear()
    {
        if(IntersectedObj.CompareTag("GravitySwitcher"))
            IntersectedObj.GetComponent<GravitySwitcher>().Interaction(this);
        if (IntersectedObj.CompareTag("SpaceSuit"))
            IntersectedObj.GetComponent<SpaceSuit>().Interaction(this);
        if (IntersectedObj.CompareTag("ItemBox"))
            IntersectedObj.GetComponent<ItemBox>().Interaction(this);
    }

    public void OnInteractionButton()
    {
        DoSmthIfSomeObjectNear();
    }

}
