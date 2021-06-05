using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsHelper : MonoBehaviour
{
    
    [SerializeField] private Player Player;
    [SerializeField] private GravitySwitcher GravitySwitcher;
    [SerializeField] private Puzzle Puzzle;
    [SerializeField] public bool IsCompleted;


    private int CurrentQuest;
    private Vector2 StartPosition;
    private bool IsWalkedLeft;
    private bool IsWalkedRight;
    private bool IsJumpedNormalForce;


    void Start()
    {
        CurrentQuest = 1;
        StartPosition = Player.RigitBody.position;
    }

    void Update()
    {
        if (CurrentQuest == 1 && CheckFirstQuest())
            CurrentQuest++;
        if (CurrentQuest == 2 && CheckSecondQuest())
            CurrentQuest++;
        if (CurrentQuest == 3 && CheckThirdQuest())
            CurrentQuest++;
        if (CurrentQuest == 4 && CheckFourthQuest())
            CurrentQuest++;
        if (CurrentQuest == 5 && CheckFifthQuest())
            CurrentQuest++;
        if (CurrentQuest == 6 && CheckSixthQuest())
            CurrentQuest++;
        if (CurrentQuest == 7 && CheckSeventhQuest())
            CurrentQuest++;
        if (CurrentQuest == 8 && CheckEighthQuest())
            CurrentQuest++;
    }

    private bool CheckFirstQuest()
    {
        if (Player.RigitBody.position.x > StartPosition.x)
            IsWalkedRight = true;
        if (Player.RigitBody.position.x < StartPosition.x)
            IsWalkedLeft = true;
        return IsWalkedLeft && IsWalkedRight;
    }

    private bool CheckSecondQuest()
    {
        return Player.RigitBody.position.y > StartPosition.y;
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
