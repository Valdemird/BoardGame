using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{

    private Square data;
    private int depth;
    private Node parent;
    private int action;

    public Square Data { get => data; set => data = value; }
    public int Depth { get => depth; set => depth = value; }
    public Node Parent { get => parent; set => parent = value; }
    public int Action { get => action; set => action = value; }

    public Node(Square data)
    {
        Depth = 0;
        this.Parent = null;
        this.Data = data;
    }

    public Node(Square data, Node parent)
    {
        Depth = parent.Depth + 1;
        this.Parent = parent;
        this.Data = data;
    }



    public override bool Equals(object obj)
    {
        var node = obj as Node;
        return node != null &&
               EqualityComparer<Square>.Default.Equals(Data, node.Data);
    }

    static public bool wasOnTheWay(Node node)
    {
        Node currentNode = node;
        node = node.parent;
        while (node != null)
        {
            if (currentNode.Equals(node))
                return true;
            node = node.parent;
        }

        return false;
    }

}
