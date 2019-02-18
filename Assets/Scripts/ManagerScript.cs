using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public static readonly string TAG = "Manager";
    public static readonly int TEAM_SELECTION = 10;
    public static readonly int MOVING = 20;
    public static readonly int ACTION = 30;
    public static readonly int IA_TURN = 40;


    //FOR TESTING
    [SerializeField]
    private int charactersNumber;
    [SerializeField]
    private int range;
    [Range(1, 10)]
    [SerializeField]
    private int mapSize;

    UIManager uiManager;
    MapCreator mapCreator;
    PathFinding pathFinding;
    Square[,] mapRepresentation;
    Square[] currentSquareGrid;
    Character[] characters;
    int currentCharacterIndex;
    // Start is called before the first frame update

    private void Awake()
    {
        uiManager = gameObject.GetComponent<UIManager>();
        mapCreator = gameObject.GetComponent<MapCreator>();
    }
    void Start()
    {
        MapGeneration();
        putCharacters();
        Character currentCharacter = characters[currentCharacterIndex];
        uiManager.setCharacterInfo("" + currentCharacterIndex, currentCharacter.Velocity, currentCharacter.Jump);
        PreMovement(currentCharacter.Velocity,currentCharacter.Jump, currentCharacter.CurrentSquare);

    }


    private void MapGeneration()
    {
        mapRepresentation = mapCreator.generateRepresentation(mapSize, mapSize);
        mapCreator.generateWorld(mapRepresentation);
    }

    private void putCharacters()
    {
        characters = new Character[charactersNumber];
        for (int i = 0; i < characters.Length; i++)
        {

            Character tmp = Character.generateTestingCharacter(mapRepresentation[0, i]);
            characters[i] = tmp;

        }
        currentCharacterIndex = 0;
    }



    private void PreMovement(int range,int jump, Square currentPosition)
    {
        pathFinding = new PathFinding(range,jump, mapRepresentation, currentPosition);
        pathFinding.Search();
        currentSquareGrid = pathFinding.getMoveArea();
        mapCreator.cleanGrid();
        mapCreator.showGrid(currentSquareGrid);
    }



    public void MoveOverGrid(int posX, int posY)
    {

        Square[] currentPath = pathFinding.getMoveRoute(posX, posY);
        mapCreator.RenderingPath(currentPath);
    }




    public void move(int posX, int posY)
    {
        characters[currentCharacterIndex].CurrentSquare = mapRepresentation[posX, posY];
        mapCreator.cleanRenderingPath();

        //
        nextCharacter();
        Character currentCharacter = characters[currentCharacterIndex];
        PreMovement(currentCharacter.Velocity, currentCharacter.Jump, currentCharacter.CurrentSquare);

    }

    public void nextCharacter()
    {
        bool isAvailable = false;
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;
        uiManager.setCharacterInfo("" + currentCharacterIndex,characters[currentCharacterIndex].Velocity,characters[currentCharacterIndex].Jump);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
