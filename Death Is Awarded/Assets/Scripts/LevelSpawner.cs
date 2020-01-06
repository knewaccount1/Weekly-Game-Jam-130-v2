using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    int waveIndex = 0;
    public GameObject[] waves;
    public Transform levelContainer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LevelSpawnCollider")
        {
            Debug.Log("collion between " + gameObject + " and " + collision.gameObject);
            
            Instantiate(waves[waveIndex], levelContainer);
            waveIndex++;
        }
    }
}
