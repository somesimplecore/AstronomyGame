using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsChecker : MonoBehaviour
{
    
    [SerializeField] private Player Player;
    [SerializeField] private GravitySwitcher GravitySwitcher;
    [SerializeField] private Puzzle Puzzle;
    [SerializeField] private SpaceSuit SpaceSuit;
    [SerializeField] private ItemBox ItemBox;



    public bool IsLevelCompleted;
    public int CurrentQuest;
    public Vector2 StartPosition;
    public float CurrentPosition;
    public bool IsWalkedLeft;
    public bool IsWalkedRight;
    public int JumpCount;


    void Start()
    {
        CurrentQuest = 1;
        StartPosition = Player.RigitBody.position;
        GravitySwitcher.tag = "Untagged";
        Puzzle.tag = "Untagged";
        SpaceSuit.tag = "Untagged";
        ItemBox.tag = "Untagged";
    }

    void Update()
    {
        CurrentPosition = Player.RigitBody.position.x;
        if (CurrentQuest == 1 && CheckFirstQuest())
            CurrentQuest++;
        if (CurrentQuest == 2 && CheckSecondQuest())
        {
            CurrentQuest++;
            SpaceSuit.tag = "SpaceSuit";
        }
        if (CurrentQuest == 3 && CheckThirdQuest())
        {
            CurrentQuest++;
            SpaceSuit.tag = "Untagged";
            ItemBox.tag = "ItemBox";
        }
        if (CurrentQuest == 4 && CheckFourthQuest())
        {
            CurrentQuest++;
            ItemBox.tag = "Untagged";
            GravitySwitcher.tag = "GravitySwitcher";
        }
        if (CurrentQuest == 5 && CheckFifthQuest())
            CurrentQuest++;
        if (CurrentQuest == 6 && CheckSixthQuest())
        {
            CurrentQuest++;
            GravitySwitcher.tag = "Untagged";
            SpaceSuit.tag = "SpaceSuit";
        }
        if (CurrentQuest == 7 && CheckSeventhQuest())
        {
            CurrentQuest++;
            SpaceSuit.tag = "Untagged";
            Puzzle.tag = "Puzzle";
        }
        if (CurrentQuest == 8 && CheckEighthQuest())
        {
            CurrentQuest++;
            Puzzle.tag = "Untagged";
        }
        if (CurrentQuest == 9)
            Player.CanEndLevel = true;
            
    }

    private bool CheckFirstQuest()
    {
        if (Player.RigitBody.position.x > StartPosition.x)
        {
            IsWalkedRight = true;
            StartPosition = Player.RigitBody.position;
        }
        if (Player.RigitBody.position.x < StartPosition.x)
        {
            IsWalkedLeft = true;
            StartPosition = Player.RigitBody.position;
        }
        return IsWalkedLeft && IsWalkedRight;
    }

    private bool CheckSecondQuest()
    {
        return JumpCount == 2;
    }

    public void CountJump()
    {
        if (CurrentQuest == 2)
            JumpCount++;
    }

    private bool CheckThirdQuest()
    {
        return Player.CurrentSprite.CompareTag("SpriteInSpaceSuit");
    }
    
    private bool CheckFourthQuest()
    {
        return Player.Inventory.IsFool[0];
    }

    private bool CheckFifthQuest()
    {
        return GravitySwitcher.SpriteWhenOn.enabled && StartPosition.y < Player.RigitBody.position.y;
    }
    
    private bool CheckSixthQuest()
    {
        return GravitySwitcher.SpriteWhenOff.enabled;
    }
    
    private bool CheckSeventhQuest()
    {
        return Player.CurrentSprite.CompareTag("SpriteWithoutSpaceSuit");
    }
    
    private bool CheckEighthQuest()
    {
        return Puzzle.IsSolved;
    }
}
