using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSquare : MonoBehaviour
{
    public static bool allActivate = true;

    private int posX;
    private int posY;
    private int elevation;
    private bool posibleToMove;
    private Transform child;
    private ManagerScript manager;
    private GameObject posibleMoveObject;

    private void Awake()
    {
        posibleMoveObject = transform.GetChild(0).gameObject;
        child = GetComponentInChildren<Transform>();
        manager = GameObject.FindGameObjectWithTag(ManagerScript.TAG).GetComponent<ManagerScript>();
        posibleToMove = false;

    }

    private void Start()
    {

    }



    public int PosX { get => posX; set => posX = value; }
    public int PosY { get => posY; set => posY = value; }
    public bool PosibleToMove { get => posibleToMove; }
    public int Elevation { get => elevation; set => elevation = value; }

    public void setPosibleToMove(bool value)
    {
        posibleToMove = value;
        posibleMoveObject.SetActive(value);
    }

    private void OnMouseUpAsButton()
    {
        if (allActivate && posibleToMove)
        {
            manager.move(posX, posY);
        }

    }

    private void OnMouseEnter()
    {
        if (allActivate && posibleToMove)
        {
            manager.MoveOverGrid(posX, posY);
        }

    }

    private void OnMouseExit()
    {
        if (allActivate && posibleToMove)
        {
        }

    }
}
