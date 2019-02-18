using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterBase
{
    private bool waitingForAction;
    int currentLife;

    public Character(Square position)
    {
        isAvailable = true;
    }

    public int CurrentLife { get => currentLife; set => currentLife = value; }
    public bool isAvailable { get => waitingForAction; set => waitingForAction = value; }

    public static Character generateTestingCharacter(Square position)
    {
        Character testingCharacter = new Character(position);
        testingCharacter.Velocity = Random.Range(6, 9);
        testingCharacter.Jump = Random.Range(0, 3);
        testingCharacter.MaxLife = Random.Range(100, 300);
        testingCharacter.currentLife = testingCharacter.MaxLife;
        testingCharacter.Accuracy = Random.Range(2, 5);
        testingCharacter.Dodge = Random.Range(2, 5);
        testingCharacter.CurrentSquare = position;


        return testingCharacter;
    }
}
