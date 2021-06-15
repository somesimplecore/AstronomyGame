using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool Bool;
    public float Speed = 3;
    public float JumpForce = 5;
    public Inventory Inventory;
    public Animator Animation;
    public SpriteRenderer SpriteRenderer;
    public GroundChecker GroundChecker;

    public Rigidbody2D RigitBody;
    public bool IsInSpaceSuit;
    public bool IsGrounded;
    public bool CanEndLevel;
    public bool IsRunning;

    private float DirectionValue = 0;
    private bool IsRunButtonPressed;

    public GameObject IntersectedObj;


    private void Start()
    {

    }

    private void FixedUpdate()
    {

    }

    private void Update()
    {
        Run();
        IsRunningCheck();
        Animation.SetBool("IsJumping", !GroundChecker.IsGrounded);
        Animation.SetBool("IsRunning", IsRunning);
        Animation.SetBool("IsInSpaceSuit", IsInSpaceSuit);
    }

    private void Run()
    {
        RigitBody.velocity = new Vector2(DirectionValue * Speed, RigitBody.velocity.y);
    }

    public void OnLeftButtonDown()
    {
        DirectionValue = -1;
        SpriteRenderer.flipX = true;
    }

    public void OnRightButtonDown()
    {
        DirectionValue = 1;
        SpriteRenderer.flipX = false;
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
        if (GroundChecker.IsGrounded)
            Jump();
    }

    private void DoSmthIfSomeObjectNear()
    {
        if(IntersectedObj.CompareTag("GravitySwitcher"))
            IntersectedObj.GetComponent<GravitySwitcher>().Interaction(this);
        if (IntersectedObj.CompareTag("SpaceSuit"))
            IntersectedObj.GetComponent<SpaceSuit>().Interaction(this);
        if (IntersectedObj.CompareTag("ItemBox"))
            IntersectedObj.GetComponent<ItemBox>().Interaction(this);
        if (IntersectedObj.CompareTag("PuzzleInteractionScreen"))
            IntersectedObj.GetComponent<PuzzleInteractionScreen>().Interaction(this);
        if (IntersectedObj.CompareTag("LevelExit"))
            IntersectedObj.GetComponent<LevelExit>().Interaction(this);
    }

    public void OnInteractionButton()
    {
        DoSmthIfSomeObjectNear();
    }

    private void IsRunningCheck()
    {
        IsRunning = DirectionValue != 0;
    }
}
