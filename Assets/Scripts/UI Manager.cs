using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public static UIManager uimanager;

    public void Game2Players() {
        GameManager.gameManager.playersHomes[1].SetActive(false);
        GameManager.gameManager.playersHomes[3].SetActive(false);
        GameManager.gameManager.totalPlayersNumbers = 2;
        mainMenuPanel.SetActive(false);
        GameManager.gameManager.mainMenuSound.Pause();
        gamePanel.SetActive(true);     
    }
    public void Game4Players()
    {
        GameManager.gameManager.totalPlayersNumbers = 4;
        mainMenuPanel.SetActive(false);
        GameManager.gameManager.mainMenuSound.Pause();
        gamePanel.SetActive(true);
    }
    /*public void GameWon() { 
    gameOverPanel.SetActive(false);
    if(gameOverPanel.activeSelf==true)GameManager.gameManager.winSound.Play();
  
    }*/

    
    
    

    
}
