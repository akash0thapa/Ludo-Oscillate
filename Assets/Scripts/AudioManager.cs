using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager audioManager;
   public bool sound = true;
   public AudioSource mainMenuMusic,saveSound;


    private void Awake()
    {
      
        saveSound = GetComponent<AudioSource>();
    }

    public void playMainMenuMusic() {
        mainMenuMusic.Play();
   }

  public void playSaveSound() {
      saveSound.Play();
   }
  
  
}
