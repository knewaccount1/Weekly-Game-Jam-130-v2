using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnEnemy : MonoBehaviour
{
    public float jumpOffEnemyForce = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().PlayAudio("Enemy Stomp");
                GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * jumpOffEnemyForce;
            }
       
    }
}
