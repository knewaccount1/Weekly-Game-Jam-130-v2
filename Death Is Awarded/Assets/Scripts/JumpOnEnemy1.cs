using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpOnEnemy1 : MonoBehaviour
{
    public float jumpOffEnemyForce = 10;
    public TextMeshProUGUI scoreText;
    public int score;
    ScoreManager scoreManager;
    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "Enemy")
            {
            Debug.Log(collision);
            //score = score + 10;
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().PlayAudio("Enemy Stomp");
                GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * jumpOffEnemyForce;
                //scoreText.text = "Score: " + score;
            scoreManager.AddScore(10);
            }
       
    }
}
