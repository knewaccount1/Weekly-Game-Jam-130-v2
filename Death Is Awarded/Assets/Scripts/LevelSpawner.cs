using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class LevelSpawner : MonoBehaviour
{
    int waveIndex = 0;
    int textIndex = 0;
    public GameObject[] waves;
    public string[] gameText;
    public Transform levelContainer;
    public TextMeshProUGUI deathText;
    private CameraScroll cameraSpeed;
    public float speedAdded;
    

    private void Start()
    {
        cameraSpeed = GetComponentInParent<CameraScroll>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LevelSpawnCollider")
        {
            Debug.Log("collion between " + gameObject + " and " + collision.gameObject);
            
            Instantiate(waves[waveIndex], levelContainer);
            waveIndex++;

            cameraSpeed.SpeedUp(speedAdded);
            StartCoroutine(ShowText());
       
        }
    }
    IEnumerator ShowText()
    {
        deathText.gameObject.SetActive(true);
        deathText.text = gameText[textIndex];
        yield return new WaitForSeconds(5f);
        deathText.gameObject.SetActive(false);
        textIndex++;
     

        
    }
}
