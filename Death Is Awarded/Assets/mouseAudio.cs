using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseAudio : MonoBehaviour
{
    // Start is called before the first frame update
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void PlayCursor()
    {
        audioManager.PlayAudio("Cursor");
    }
}
