using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillPlayer : MonoBehaviour
{
    public bool isPlayer;
    Transform spawnPoint;
    Rigidbody2D rb;
    PlayerPlatformerController playerController;
    SpriteRenderer sr;
    [SerializeField] float timeToRespawn;
    [SerializeField] float invulnTime;
    BoxCollider2D playerCollider;
    public bool invuln;
    Transform playerTransform;
    public TextMeshProUGUI respawnText;


    private void Start()
    {
        if (isPlayer)
        {
            rb = GetComponent<Rigidbody2D>();
            playerController = GetComponent<PlayerPlatformerController>();
            sr = GetComponent<SpriteRenderer>();
            spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
            playerCollider = GetComponent<BoxCollider2D>();
            playerTransform = GetComponent<Transform>();
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
        invuln = true;
        respawnText.gameObject.SetActive(false);
        FindObjectOfType<AudioManager>().PlayAudio("Power Up");
        Invoke("ResetInvuln", invulnTime);

    }

    public void KillMyself()
    {

        if (!invuln)
        {
            playerController.enabled = false;
            sr.enabled = false;
            playerController.maxSpeed += 3;
            playerController.jumpTakeOffSpeed += 3;
            respawnText.gameObject.SetActive(true);
            respawnText.text = "YES BILL, YOU'RE GETTING STRONG ACCEPT ME";
            playerCollider.enabled = false;
            FindObjectOfType<AudioManager>().PlayAudio("Player Death");
            StartCoroutine(RespawnPlayer());
        }
    }

    void ResetInvuln()
    {
        invuln = false;

    }

}
