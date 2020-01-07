using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    ScoreManager scoreManager;
    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            FindObjectOfType<AudioManager>().PlayAudio("Coin");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            scoreManager.AddScore(50);
            Destroy(gameObject);
        }
    }
}
