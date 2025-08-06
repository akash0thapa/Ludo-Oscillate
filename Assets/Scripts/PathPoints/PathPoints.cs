using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathPoints : MonoBehaviour
{
    public PathPointsParent pathParent;
    public List<PlayerPiece> piecesList = new List<PlayerPiece>();
    PathPoints[] reverseMovePath;
    public string winnerName = null;


    public void Start()
    {
        pathParent = GetComponentInParent<PathPointsParent>();
    }
    public bool AddPlayerPieces(PlayerPiece piece)
    {
        if (this.name=="Final PathPoint") {
            AddPlayer(piece);
            complete(piece);
            GameWon(piece);
            return false;
        }
        for (int i = 0; i < 4; i++) {
            if (piece.transform.position == pathParent.safePathPoints[i].transform.position ) {
                Debug.Log("HEHHEHHEE");
               if ( GameManager.gameManager.sound)
                {
                    GameManager.gameManager.pieceMoveSound.Pause();
                    GameManager.gameManager.saveSound.Play();
                }
                else
                {
                    Debug.LogWarning("AudioManager is not initialized or sound is disabled.");
                }
            }
        }
        /*if (pathParent.safePathPoints.Contains(this))
        {
            if (AudioManager.audioManager.sound)
            {
                AudioManager.audioManager.playSaveSound(); 
            }
        }*/
        if (!pathParent.safePathPoints.Contains(this))
        {         
            if (piecesList.Count == 1)
            {
                string prePieceName = piecesList[0].name;
                string currentPieceName = piece.name;
                if (!prePieceName.Contains(currentPieceName) && piece.moveDirection == true)
                {
                    piecesList[0].isReady = false;
                    StartCoroutine(RevertToStart(piecesList[0]));
                    piecesList[0].numberOfStepsAlreadyMoved = 0;
                    RemovePlayerPieces(piecesList[0]);
                    AddPlayer(piece);
                    return false;
                }
            }
        }
        AddPlayer(piece);
        return true;
    }
    public void complete(PlayerPiece piece) {
        int player;
        if (piece.name.Contains("Red"))
        {
            player=GameManager.gameManager.redPlayerOut -= 1;
        }
        else if (piece.name.Contains("Blue"))
        {
            player=GameManager.gameManager.bluePlayerOut -= 1;
        }
        else if (piece.name.Contains("Yellow"))
        {
            player=GameManager.gameManager.yellowPlayerOut -= 1;
        }
        else
        {
            player=GameManager.gameManager.greenPlayerOut -= 1;
        }
        if (player == 0) {
            int a=GameManager.gameManager.rollingDiceList.Count;
            string temp = piece.name;   
            Debug.Log(temp);
            int x=0;
            for (int i = 0; i < a; i++)
            {
                string t = GameManager.gameManager.rollingDiceList[i].name.Substring(13);
                Debug.Log(t);
                if (temp.Contains(t)){
                     x= i;
                    GameManager.gameManager.transferDice = true;
                    GameManager.gameManager.turnCompleted = true;
                    GameManager.gameManager.rollingDiceTransfer();
                    GameManager.gameManager.rollingDiceList.Remove(GameManager.gameManager.rollingDiceList[i]);
                    piece.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }

    public bool GameWon(PlayerPiece piece) {
        if (piece.currentPathPoint.name == "Final PathPoint") {
            GameManager.gameManager.winnerPiece = piece;
           GameManager.gameManager.gamePanel.SetActive(false);
            GameManager.gameManager.gameOverPanel.SetActive(true); 
            GameManager.gameManager.winSound.Play();
            return true;
        }
        return false;
    }

    public IEnumerator RevertToStart(PlayerPiece piece) {
        if (piece.name.Contains("RedPiece"))
        {
            reverseMovePath = pathParent.redPathPoints;
            for (int i = piece.numberOfStepsAlreadyMoved - 1; i >= 0; i--) {
                piece.transform.position = reverseMovePath[i].transform.position;
                if (GameManager.gameManager.sound) GameManager.gameManager.pieceMoveSound.Play();
                yield return new WaitForSeconds(0.05f);
            }
            piece.transform.position = new Vector3(1.16f, -0.642f, 0f);
            GameManager.gameManager.redPlayerOut--;
        }
        else if (piece.name.Contains("BluePiece"))
        {

            reverseMovePath = pathParent.bluePathPoints;
            for (int i = piece.numberOfStepsAlreadyMoved - 1; i >= 0; i--)
            {
                piece.transform.position = reverseMovePath[i].transform.position;
                if (GameManager.gameManager.sound) GameManager.gameManager.pieceMoveSound.Play();
                yield return new WaitForSeconds(0.05f);
            }
            piece.transform.position = new Vector3(-1.159f, -0.62f, 0f);
            GameManager.gameManager.bluePlayerOut--;
        }
        else if (piece.name.Contains("YellowPiece"))
        {
            reverseMovePath = pathParent.yellowPathPoints;
            for (int i = piece.numberOfStepsAlreadyMoved - 1; i >= 0; i--)
            {
                piece.transform.position = reverseMovePath[i].transform.position;
                if (GameManager.gameManager.sound) GameManager.gameManager.pieceMoveSound.Play();
                yield return new WaitForSeconds(0.05f);
            }
            piece.transform.position = new Vector3(-1.14f, 1.687f, 0f);
            GameManager.gameManager.yellowPlayerOut--;
        }
        else
        {
            reverseMovePath = pathParent.greenPathPoints;
            for (int i = piece.numberOfStepsAlreadyMoved - 1; i >= 0; i--)
            {
                piece.transform.position = reverseMovePath[i].transform.position;
                if (GameManager.gameManager.sound) GameManager.gameManager.pieceMoveSound.Play();
                yield return new WaitForSeconds(0.05f);
            }
            piece.transform.position = new Vector3(1.18f, 1.677f, 0f);
            GameManager.gameManager.greenPlayerOut--;
        }
        piece.isReady = false;
    }
    private void AddPlayer(PlayerPiece piece)
    {
        piecesList.Add(piece);
        RescaleAndReposition();
        int SpriteLayer = 0;
        for (int i = 0; i < piecesList.Count; i++)
        {
            SpriteRenderer[] spriteRenderers = piecesList[i].GetComponentsInChildren<SpriteRenderer>();
            if (i == piecesList.Count - 1)
            {
                foreach (SpriteRenderer renderer in spriteRenderers)
                {
                    renderer.sortingOrder = renderer.sortingOrder + (SpriteLayer + i);
                }
            }
            SpriteLayer += 4;

        }
    }

    public void RemovePlayerPieces(PlayerPiece piece)
    {
        if (piecesList.Contains(piece))
        {
            piecesList.Remove(piece);
            RescaleAndReposition();
        }
        Debug.Log(piecesList.Count);
        if (piecesList.Count > 0)
        {
              foreach (PlayerPiece p in piecesList) { 
                SpriteRenderer[] spriteRenderers = p.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer renderer in spriteRenderers)
                {
                    renderer.sortingOrder = renderer.sortingOrder - 5;
                }            
            }
        }
    }

    public void RescaleAndReposition()
    {
        int playersCount = piecesList.Count;
        switch (playersCount) {
            case 1:
                piecesList[0].transform.localScale = new Vector3(0.35f, 0.35f, 1f);
                piecesList[0].transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                break;

            case 2:
                piecesList[0].transform.localScale = new Vector3(0.3f, 0.3f, 1f);
                piecesList[1].transform.localScale = new Vector3(0.3f, 0.3f, 1f);
                piecesList[0].transform.position = new Vector3(transform.position.x + 0.075f, transform.position.y, 0f);
                piecesList[1].transform.position = new Vector3(transform.position.x-0.075f, transform.position.y, 0f);
                break;

            case 3:
                piecesList[0].transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, 0f);
                piecesList[1].transform.position = new Vector3(transform.position.x + 0.03f, transform.position.y, 0f);
                piecesList[2].transform.position = new Vector3(transform.position.x - 0.045f + 0.03f, transform.position.y, 0f);
                piecesList[0].transform.localScale = new Vector3(0.25f, 0.25f, 25f);
                piecesList[1].transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                piecesList[2].transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                break;

            case 4:
                piecesList[0].transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, 0f);
                piecesList[1].transform.position = new Vector3(transform.position.x + 0.03f, transform.position.y, 0f);
                piecesList[3].transform.position = new Vector3(transform.position.x - 0.115f + 0.03f, transform.position.y, 0f);
                piecesList[2].transform.position = new Vector3(transform.position.x - 0.045f + 0.03f, transform.position.y, 0f);
                piecesList[0].transform.localScale = new Vector3(0.25f, 0.25f, 25f);
                piecesList[1].transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                piecesList[2].transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                piecesList[3].transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                break;
        }      
    } 
}

     
