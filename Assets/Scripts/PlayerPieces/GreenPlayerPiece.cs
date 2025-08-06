using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerPiece : PlayerPiece
{
    RollingDice greenRollingDice;
    private void Start()
    {
        greenRollingDice = GetComponentInParent<GreenHome>().rollingDice;
    }

    public void OnMouseDown()
    {
        if (GameManager.gameManager.rolledDice != null)
        {
            if (!isReady)
            {
                if (GameManager.gameManager.rolledDice == greenRollingDice && GameManager.gameManager.moveSteps == 3 && GameManager.gameManager.canPlayerMove == true)
                {
                    GameManager.gameManager.greenPlayerOut++;
                    MakePlayerReadyToMove(pathParent.greenPathPoints);
                    CircleCollider2D col = this.GetComponent<CircleCollider2D>();
                    col.enabled = false;
                    GameManager.gameManager.moveSteps = 0;
                    return;
                }
            }
            else
            {
                if (GameManager.gameManager.rolledDice == greenRollingDice && GameManager.gameManager.canPlayerMove == true && GameManager.gameManager.turnCompleted == false)
                {
                    GameManager.gameManager.canPlayerMove = false;
                    GameManager.gameManager.turnCompleted = true;
                    MovePlayer(pathParent.greenPathPoints);
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
