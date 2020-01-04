using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCorpse : MonoBehaviour
{
    public GameObject playerPrefab; //prefab for spawning new player
    public Transform spawnPoint;    //spawn point in the scene


    private void Awake()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform; // find the spawn point in the scene
    }
    private void OnTriggerEnter2D(Collider2D collision) //collision with death walls
    {
       
        if (collision.tag == "Deathwall")
        {
            Debug.Log("collision with " + collision.gameObject);
            Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
            gameObject.GetComponent<PlayerPlatformerController>().enabled = false;


        }
    }
}
