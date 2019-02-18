using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PathFinding
{

    private const int DOWN = -2;
    private const int LEFT = -1;
    private const int RIGHT = 1;
    private const int UP = 2;

    private int depth;
    private int verticalMove;
    private Square[,] mapRepresentation;
    private Square origin;
    private Node[,] result;

    public PathFinding(int depth,int verticalMove, Square[,] mapRepresentation, Square firstSquare)
    {
        this.depth = depth;
        this.verticalMove = verticalMove;
        this.mapRepresentation = mapRepresentation;
        this.result = new Node[mapRepresentation.GetLength(0), mapRepresentation.GetLength(1)];
        this.origin = firstSquare;
    }

    public Square Origin { get => origin; set => origin = value; }

    public Square[] getMoveArea()
    {
        List<Square> moveSquare = new List<Square>();
        foreach (Node node in result)
        {
            if (node != null)
            {
                Debug.Log(node.Data.ToString());
                moveSquare.Add(node.Data);
            }
        }
        return moveSquare.ToArray();
    }

    public Square[] getMoveRoute(int posX, int posY)
    {

        Node currentNode = result[posX, posY];
        Debug.Log(currentNode.Data.ToString());
        List<Square> elements = new List<Square>();
        while (currentNode.Parent != null)
        {
            elements.Add(currentNode.Data);
            currentNode = currentNode.Parent;
        }
        elements.Add(Origin);
        return elements.ToArray();
    }


    public void Search()
    {
        
        BusquedaPorAmplitud();
    }

    private void BusquedaPorAmplitud()
    {
        Node firstNode = new Node(Origin);
        List<Node> nodosVisitados = new List<Node>();
        Queue<Node> nodosFrontera = new Queue<Node>();
        Node currentNode = null;
        nodosFrontera.Enqueue(firstNode);
        while (nodosFrontera.Count != 0)
        {
            currentNode = nodosFrontera.Dequeue();
            if (currentNode.Depth < depth)
            {
                nodosVisitados.Add(currentNode);
                for (int i = DOWN; i <= UP; i++)
                {
                    Node son = Move(currentNode, i);
                    if (son != null && !nodosFrontera.Contains(son) && !Node.wasOnTheWay(son)/*!nodosVisitados.Contains(son)*/)
                    {
                        int x = son.Data.PosX;
                        int y = son.Data.PosY;
                        if (result[x, y] != null)
                        {
                            if (result[x, y].Depth > son.Depth)
                            {
                                result[x, y] = son;
                            }
                        }
                        else
                        {
                            result[x, y] = son;
                        }
                        nodosFrontera.Enqueue(son);
                    }
                }
            }
        }

    }



    private Node Move(Node currentNode, int direccion)
    {
        int posX = currentNode.Data.PosX;
        int posY = currentNode.Data.PosY;
        int elevation = currentNode.Data.Elevation;
        int action = -1;
        switch (direccion)
        {
            case LEFT:
                action = direccion;
                posX--;
                break;
            case RIGHT:
                action = direccion;
                posX++;
                break;
            case DOWN:
                action = direccion;
                posY++;
                break;
            case UP:
                action = direccion;
                posY--;
                break;
            default:
                break;
        }

        if (posX >= 0 && posX < mapRepresentation.GetLength(0) && posY >= 0 && posY < mapRepresentation.GetLength(1) && (mapRepresentation[posX, posY].Elevation <= verticalMove))
        {
            Debug.Log("elevation: " + elevation);
            Square newSquare = new Square(posX, posY, elevation);
            Node moveNode = new Node(newSquare, currentNode);
            moveNode.Action = action;
            return moveNode;
        }
        else
        {
            return null;
        }
    }

}
