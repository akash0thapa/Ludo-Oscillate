using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WinnerName : MonoBehaviour
{
    public TextMeshProUGUI winnerName;
 

    public void Awake()
    {
        if (GameManager.gameManager.winnerPiece.name.Contains("Red"))
        {
            winnerName.text = "RED";
            winnerName.color = Color.red;
        }
        else if (GameManager.gameManager.winnerPiece.name.Contains("Blue"))
        {
            winnerName.text = "BLUE";
            winnerName.color = Color.blue;
        }
        else if (GameManager.gameManager.winnerPiece.name.Contains("Yellow"))
        {
            winnerName.text = "YELLOW";
            winnerName.color = Color.yellow;
        }
        else
        {
            winnerName.text = "GREEN";
            winnerName.color = Color.green;
        }   
        
    }

   
}
