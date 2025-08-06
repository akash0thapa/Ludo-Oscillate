using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource diceRollAudio, buttonClickAudio;
    public void Start()
    {
        diceRollAudio = GetComponent<AudioSource>();
        buttonClickAudio= GetComponent<AudioSource>();
    }
    public void DiceRollAudio() { 
    diceRollAudio.Play();
    }

    public void ButtonClickAudio() { 
    buttonClickAudio.Play();
    }

   /* public void PlayMainMenuMusic() { 
    GameManager.gameManager.mainMenuSound.Play();
    }

    public void PauseMainMenuMusic()
    {
        GameManager.gameManager.mainMenuSound.Pause();
    }
   */
   /* public void PauseAudio()
    {
        GameManager.gameManager.sound = false;
        audioPlay.gameObject.SetActive(false);
        GameManager.gameManager.pieceMove.gameObject.SetActive(false);
    }
    public void PlayAudio()
    {
        GameManager.gameManager.sound = true ;
        audioPlay.gameObject.SetActive(true);
        GameManager.gameManager.pieceMove.gameObject.SetActive(true);
    }*/

   
}
