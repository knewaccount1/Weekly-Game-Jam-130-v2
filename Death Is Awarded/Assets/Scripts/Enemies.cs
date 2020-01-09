using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float moveSpeed;
    public bool patrolUnit;
    public bool hopper;
    public bool flier;
    public float hopForce;
    public float timeBetweenHop;
    private float timeSinceHop;
    private Rigidbody2D rb;
    private AudioManager audioManager;
    ScoreManager scoreManager;




    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        rb = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
       
    }
    void Update()
    {
        if (flier)
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }
        else
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }

        HopperFunction();

    }

    private void HopperFunction()
    {
        timeSinceHop -= Time.deltaTime;

        if (timeSinceHop < 0 && hopper)
        {
            rb.velocity = new Vector2(rb.velocity.x, 1) * hopForce;
            timeSinceHop = timeBetweenHop + Random.Range(-1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (patrolUnit && collision.gameObject.tag != "Ground")
        {
            moveSpeed = moveSpeed * -1;
            Vector3 oldTrans = transform.localScale;
            oldTrans.x *= -1;
            transform.localScale = oldTrans;
            
        }
    }

    public void DestroyIt()
    {
        scoreManager.AddScore(10);
        Destroy(gameObject);
        audioManager.PlayAudio("Break Block");

    }
}
