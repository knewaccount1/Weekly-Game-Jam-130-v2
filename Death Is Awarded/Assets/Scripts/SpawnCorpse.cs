using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCorpse : MonoBehaviour
{
    public GameObject playerPrefab; //prefab for spawning new player
    public Transform spawnPoint;    //spawn point in the scene
    public float respawnTime = 1f;
    public List<GameObject> playerList; //public for debugging. List for clearing dead bodies;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            playerList.Clear();
        }
    }

    private void Awake()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform; // find the spawn point in the scene
    }
    private void OnTriggerEnter2D(Collider2D collision) //collision with death walls
    {
       
        if (collision.tag == "Deathwall")
        {
           
            gameObject.GetComponent<PlayerPlatformerController>().enabled = false; //disables current player movement
            StartCoroutine(SpawnNewPlayer()); //Coroutine for delayed respawn

        }

        if (collision.tag == "RespawnWall")
        {
           
            gameObject.transform.position = spawnPoint.position;
        }
    }
    IEnumerator SpawnNewPlayer()
    {
        yield return new WaitForSeconds(respawnTime);
        GameObject newPlayer = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        playerList.Add(newPlayer);
        Debug.Log(playerList.Count);
        newPlayer.GetComponent<PlayerPlatformerController>().enabled = true; //enable player movement (does not turn on when the previous player was disabled)
    }
}
