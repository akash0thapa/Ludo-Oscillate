using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public GameObject mainCanvas;
    public void BackToMainMenu() {
        SceneManager.LoadScene("GameScene");
    }
   public  void Exit() { 
    Application.Quit();
    }

  


}
