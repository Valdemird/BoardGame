using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SquareBase
{
    private int posX;
    private int posY;
    private int elevation;

    public int PosX { get => posX; set => posX = value; }
    public int PosY { get => posY; set => posY = value; }
    public int Elevation { get => elevation; set => elevation = value; }

    public override bool Equals(object obj)
    {
        var square = obj as Square;
        return square != null &&
               PosX == square.PosX &&
               PosY == square.PosY;
    }

}
