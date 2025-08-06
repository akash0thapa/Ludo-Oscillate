using System.Collections;
using UnityEngine;
public class RedPlayerPiece : PlayerPiece
{

    public static RollingDice redRollingDice;
    private void Start()
    {
        redRollingDice=GetComponentInParent<RedHome>().rollingDice;
    }

    public void OnMouseDown()
    {       
        if (GameManager.gameManager.rolledDice != null)
            {
            if (!isReady)
            {
                if (GameManager.gameManager.rolledDice == redRollingDice && GameManager.gameManager.moveSteps == 3 && GameManager.gameManager.canPlayerMove == true)
                {
                    GameManager.gameManager.redPlayerOut++;
                    MakePlayerReadyToMove(pathParent.redPathPoints);
                    CircleCollider2D col = this.GetComponent<CircleCollider2D>();
                    col.enabled = false;
                    GameManager.gameManager.moveSteps = 0;
                    return;
                }
            }
            else
            {      
            if (GameManager.gameManager.rolledDice == redRollingDice && GameManager.gameManager.canPlayerMove == true&& GameManager.gameManager.turnCompleted ==false)
                    {
                        GameManager.gameManager.canPlayerMove = false;
                    GameManager.gameManager.turnCompleted = true;
                    MovePlayer(pathParent.redPathPoints);
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
