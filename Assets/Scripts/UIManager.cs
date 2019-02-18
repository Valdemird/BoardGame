using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text nameInfo;
    [SerializeField]
    private Text moveInfo;
    [SerializeField]
    private Text jumpInfo;


    public void setCharacterInfo(string name, int move, int jump) {
        nameInfo.text = "Name " + name;
        moveInfo.text = "Move " + move;
        jumpInfo.text = "Jump " + jump;

    }

}
