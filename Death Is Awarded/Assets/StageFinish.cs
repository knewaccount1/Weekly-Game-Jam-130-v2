using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StageFinish : MonoBehaviour
{
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            

            Sound[] sounds = audioManager.sounds;

            foreach (Sound source in sounds)
            {
                source.source.Stop();
            }

      
            audioManager.StopAllCoroutines();
         
            audioManager.PlayAudio("Victory");
            FindObjectOfType<SceneLoader>().LoadVictoryScene();
        }
    }
}
