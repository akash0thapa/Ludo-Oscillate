using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayerPiece : PlayerPiece
{
    RollingDice yellowRollingDice;
    private void Start()
    {
        yellowRollingDice = GetComponentInParent<YellowHome>().rollingDice;
    }

    public void OnMouseDown()
    {
        if (GameManager.gameManager.rolledDice != null)
        {
            if (!isReady)
            {
                if (GameManager.gameManager.rolledDice == yellowRollingDice && GameManager.gameManager.moveSteps == 3 && GameManager.gameManager.canPlayerMove == true)
                {
                    GameManager.gameManager.yellowPlayerOut++;
                    MakePlayerReadyToMove(pathParent.yellowPathPoints);
                    CircleCollider2D col = this.GetComponent<CircleCollider2D>();
                    col.enabled = false;
                    GameManager.gameManager.moveSteps = 0;
                    return;
                }
            }
            else
            {
                if (GameManager.gameManager.rolledDice == yellowRollingDice && GameManager.gameManager.canPlayerMove == true && GameManager.gameManager.turnCompleted == false)
                {
                    GameManager.gameManager.canPlayerMove = false;
                    GameManager.gameManager.turnCompleted = true;
                    MovePlayer(pathParent.yellowPathPoints);
                    return;
                }
            }
        }

    }
    public void OnClick()
    {
        OnMouseDown();
    }
}
