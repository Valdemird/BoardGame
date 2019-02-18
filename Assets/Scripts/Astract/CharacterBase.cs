using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase
{

    Square currentSquare;
    Weapon weapon;
    Armor armor;

    int maxLife;
    int velocity;
    int accuracy;
    int jump;
    int dodge;

    public Square CurrentSquare { get => currentSquare; set => currentSquare = value; }
    public Weapon Weapon { get => weapon; set => weapon = value; }
    public Armor Armor { get => armor; set => armor = value; }
    public int Velocity { get => velocity; set => velocity = value; }
    public int Accuracy { get => accuracy; set => accuracy = value; }
    public int Jump { get => jump; set => jump = value; }
    public int Dodge { get => dodge; set => dodge = value; }
    public int MaxLife { get => maxLife; set => maxLife = value; }
}
