using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : SquareBase
{
    private int assetCode;
    private int elevation;
    private bool walkable;

    public Square(int posX, int posY, int elevation, int assetCode)
    {
        this.PosX = posX;
        this.PosY = posY;
        this.AssetCode = assetCode;
        this.Elevation = elevation;
        this.Walkable = autoWakeable();
    }

    public Square(int posX, int posY, int elevation)
    {
        this.PosX = posX;
        this.PosY = posY;
        this.AssetCode = 0;
        this.Elevation = elevation;
        this.Walkable = autoWakeable();
    }



    public int AssetCode { get => assetCode; set => assetCode = value; }
    public bool Walkable { get => walkable; set => walkable = value; }


    private bool autoWakeable()
    {
        if (elevation >= 1)
        {
            return false;
        }
        return true;
    }

    public Vector3 getVector()
    {
        return new Vector3(PosX, Elevation, PosY);
    }

    override
    public string ToString() {
        return "(" + PosX + "," + +Elevation + "," + PosY + ") " + GetHashCode();

    }

  
    
}
