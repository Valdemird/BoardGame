using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject InteractiveCube;
    [SerializeField]
    private LineRenderer pathLine;
    [SerializeField]
    private GameObject[] assets;
    private GameObject[,] map;


    public GameObject[,] Map { get => map; set => map = value; }


    public void generateWorld(Square[,] representation)
    {
        Map = new GameObject[representation.GetLength(0), representation.GetLength(1)];
        foreach (Square square in representation)
        {
            int i = 0;
            do
            {
                Vector3 position = new Vector3(square.PosX, i, square.PosY);
                GameObject cube = Instantiate(InteractiveCube, position, transform.rotation) as GameObject;
                cube.name = "(" + square.PosX + "," + square.PosY + ")";
                InteractiveSquare interactiveSquare = cube.GetComponent<InteractiveSquare>();
                interactiveSquare.PosX = square.PosX;
                interactiveSquare.PosY = square.PosY;
                interactiveSquare.Elevation = square.Elevation;
                Instantiate(assets[square.AssetCode], cube.transform);
                Map[square.PosX, square.PosY] = cube;
                i++;
            } while (i < square.Elevation + 1);
        }

    }


    public void RenderingPath(Square[] route)
    {
        float lineElevation = 0.8f;
        List<Vector3> positions = new List<Vector3>();
        for (int i = route.Length - 1; i >= 0; i--)
        {
            Vector3 position = route[i].getVector();
            position.y = position.y + lineElevation;
            positions.Add(position);
            int nextI = i - 1;
            if (nextI >= 0)
            {
                Vector3 currentPosition = route[i].getVector();
                Vector3 nextPosition = route[nextI].getVector();
                float outSetX = (nextPosition.x - currentPosition.x) / 3;
                float outSetZ = (nextPosition.z - currentPosition.z) / 3;
                if (currentPosition.y > nextPosition.y)
                {
                    positions.Add(new Vector3(nextPosition.x - outSetX, currentPosition.y + lineElevation, nextPosition.z - outSetZ));
                }
                else if (currentPosition.y < nextPosition.y)
                {
                    positions.Add(new Vector3(currentPosition.x + outSetX, nextPosition.y + lineElevation, currentPosition.z + outSetZ));
                }

            }

        }
        pathLine.positionCount = positions.Count;
        pathLine.SetPositions(positions.ToArray());
    }


    public void showGrid(Square[] squares)
    {
        foreach (Square square in squares)
        {
            if (square != null)
            {
                if (Map[square.PosX, square.PosY] != null)
                {
                    Map[square.PosX, square.PosY].GetComponentInChildren<InteractiveSquare>().setPosibleToMove(true);
                }
            }

        }
    }

    public void cleanGrid()
    {
        foreach (GameObject cube in Map)
        {
            cube.GetComponent<InteractiveSquare>().setPosibleToMove(false);
        }
    }

    public void cleanRenderingPath()
    {
        pathLine.positionCount = 0;
    }

    public Square[,] generateRepresentation(int m, int n)
    {
        Square[,] randomRep = new Square[m, n];
        for (int i = 0; i < randomRep.GetLength(0); i++)
        {
            float lengthFirstDimention = randomRep.GetLength(1);
            for (int j = 0; j < lengthFirstDimention; j++)
            {
                int value = testingElevation();
                randomRep[i, j] = new Square(i, j, value, value);
                //Debug.Log(randomRep[i, j].ToString());

            }
        }
        return randomRep;
    }

    private int testingElevation()
    {
        int randomNumber = Random.Range(0, 9999);
        if (randomNumber < 7000)
        {
            return 0;
        }
        else if (randomNumber < 9500)
        {
            return 1;

        }
        else
        {
            return 2;
        }
    }

}
