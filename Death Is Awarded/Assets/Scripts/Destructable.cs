﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void DestroyIt()
    {
        Destroy(gameObject);
        audioManager.PlayAudio("Break Block");

    }
}
