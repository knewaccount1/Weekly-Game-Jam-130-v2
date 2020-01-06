using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public bool isPlayer;
    Transform spawnPoint;
    Rigidbody2D rb;
    PlayerPlatformerController playerController;
    SpriteRenderer sr;
    [SerializeField] float timeToRespawn;
    BoxCollider2D playerCollider;

    private void Start()
    {
        if (isPlayer)
        {
            rb = GetComponent<Rigidbody2D>();
            playerController = GetComponent<PlayerPlatformerController>();
            sr = GetComponent<SpriteRenderer>();
            spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
            playerCollider = GetComponent<BoxCollider2D>();
        }
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log(collision);
            collision.GetComponent<KillPlayer>().KillMyself();
        }
    }
    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(timeToRespawn);
        transform.position = spawnPoint.position;
        playerController.enabled = true;
        sr.enabled = true;
        playerCollider.enabled = true;

    }

    public void KillMyself()
    {
        
        playerController.enabled = false;
        sr.enabled = false;
        playerCollider.enabled = false;
        FindObjectOfType<AudioManager>().PlayAudio("Player Death");
        StartCoroutine(RespawnPlayer());
    }
}
