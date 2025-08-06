using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class RollingDice : MonoBehaviour
{
    [SerializeField] int numberGot;
    [SerializeField] SpriteRenderer diceNumber;
    [SerializeField] Sprite[] diceSprites;
    [SerializeField] GameObject rollingDiceAnim;
    Coroutine generateRandomNumber;
    public static  RollingDice rollingDice;
    public PlayerPiece playerPiece;
    public PathPoints[] currentPathPoints;
    public Audio diceRollAudio;
    // Update is called once per frame

    public void OnMouseDown()
    {
        CircleCollider2D col=this.playerPiece.GetComponent<CircleCollider2D>();
        col.enabled = true;
        rollingDice = GetComponent<RollingDice>();
        generateRandomNumber = StartCoroutine(GenerateRandomNumberOnDice());
    }
    IEnumerator GenerateRandomNumberOnDice()
    {
        if (GameManager.gameManager.gameQuitCanvas.activeSelf)
        {
            GameManager.gameManager.canDiceRoll = false;
        }
        
            yield return new WaitForEndOfFrame();
            if (GameManager.gameManager.canDiceRoll)
            {
            GameManager.gameManager.canDiceRoll = false;
            Debug.Log("dice cannot be rolled now");           
                if (GameManager.gameManager.sound) diceRollAudio.DiceRollAudio();
                diceNumber.gameObject.SetActive(false);
                rollingDiceAnim.SetActive(true);
                numberGot = Random.Range(0, 6);
                diceNumber.sprite = diceSprites[numberGot];
                if (numberGot == 3) { numberGot = -1; }
                else if (numberGot == 4) { numberGot = -2; }
                else if (numberGot == 5) { numberGot = -3; }
                else numberGot += 1;
                GameManager.gameManager.moveSteps = numberGot;
                GameManager.gameManager.rolledDice = this;
                yield return new WaitForSeconds(0.5f);
                diceNumber.gameObject.SetActive(true);
                rollingDiceAnim.SetActive(false);
                yield return new WaitForSeconds(0.3f);
                if (outPlayers() == 0)
                {
                    if (GameManager.gameManager.moveSteps != 3)
                    {
                        GameManager.gameManager.turnCompleted = true;
                        GameManager.gameManager.transferDice = true;
                        GameManager.gameManager.rollingDiceTransfer();
                    }
                }
                if (outPlayers() != 0)
                {
                    int total = this.playerPiece.numberOfStepsAlreadyMoved + GameManager.gameManager.moveSteps;
                    if (GameManager.gameManager.moveSteps > 0)
                    {
                        if (total > 33)
                        {
                            GameManager.gameManager.turnCompleted = true;
                            GameManager.gameManager.transferDice = true;
                            GameManager.gameManager.rollingDiceTransfer();
                        }
                        else
                        {
                            GameManager.gameManager.turnCompleted = false;
                            GameManager.gameManager.transferDice = false;
                        }

                    }
                    else
                    {
                        if (total <= 0)
                        {
                            GameManager.gameManager.turnCompleted = true;
                            GameManager.gameManager.transferDice = true;
                            GameManager.gameManager.rollingDiceTransfer();
                        }
                        else
                        {
                            GameManager.gameManager.turnCompleted = false;
                            GameManager.gameManager.transferDice = false;
                        }

                    }
                }

                yield return new WaitForEndOfFrame();
                if (generateRandomNumber != null)
                {
                    StopCoroutine(generateRandomNumber);
                }


            }
        }
    
    
    public int outPlayers()
    {
        if (GameManager.gameManager.rolledDice == GameManager.gameManager.rollingDiceList[0])
        {
            return GameManager.gameManager.redPlayerOut;
        }
        else if (GameManager.gameManager.rolledDice == GameManager.gameManager.rollingDiceList[1])
        {
            return GameManager.gameManager.bluePlayerOut;
        }
        else if (GameManager.gameManager.rolledDice == GameManager.gameManager.rollingDiceList[2])
        {
            return GameManager.gameManager.yellowPlayerOut;
        }
        else
        {
            return GameManager.gameManager.greenPlayerOut;
        }
    }

 
    public void OnClick()
    {
        OnMouseDown();
    }
}
