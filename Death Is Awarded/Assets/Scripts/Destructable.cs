using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{

    private AudioManager audioManager;
    ScoreManager scoreManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    public void DestroyIt()
    {
        scoreManager.AddScore(5);
        Destroy(gameObject);
        audioManager.PlayAudio("Break Block");

    }
}
