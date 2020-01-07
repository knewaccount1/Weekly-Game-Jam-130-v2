using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevelSong : MonoBehaviour
{
    AudioManager audioManager;
    AudioSource source;
    public AudioClip clipIntro;
    public AudioClip theme;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clipIntro;
        source.Play();
        StartCoroutine(PlayTheme());
    }

    IEnumerator PlayTheme()
    {
        yield return new WaitForSeconds(clipIntro.length);
        source.clip = theme;
        source.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
