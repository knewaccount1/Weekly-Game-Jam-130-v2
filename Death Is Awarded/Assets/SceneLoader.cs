using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int startingSceneIndex = 0;
    public float delayInSeconds = 1f;
    public int sceneIndex;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(startingSceneIndex);
        sceneIndex = 0;
    }

    public void LoadGame()
    {
        //GameManager.IsInputEnabled = true;
        sceneIndex = 1;
        
        Sound[] sounds = FindObjectOfType<AudioManager>().sounds;

        foreach(Sound source in sounds)
        {
            source.source.Stop();
        }

        SceneManager.LoadScene(sceneIndex);
        audioManager.StopAllCoroutines();
       
      
        //StartCoroutine(PlaySong());

    }

    IEnumerator PlaySong()
    {
        audioManager.PlayAudio("Level 1 Theme Intro");
        
        yield return new WaitForSeconds(audioManager.sounds[11].source.clip.length);
        audioManager.PlayAudio("Level 1 Theme");
        Debug.Log(audioManager.sounds[11].source.clip.name);
    }
    

    public void LoadNextScene()
    {
        sceneIndex++;
        StartCoroutine(WaitandLoadNextScene());
        //Debug.Log(sceneIndex);

    }

    IEnumerator WaitandLoadNextScene()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoadGameOver());
        //FindObjectOfType<GameRunner>().ResetGame();

    }

    IEnumerator WaitAndLoadGameOver()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

    public void LoadVictoryScene()
    {
        StartCoroutine(WaitandLoadVictoryScene());
        sceneIndex = 1;

    }

    IEnumerator WaitandLoadVictoryScene()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Victory Scene");
    }

    public void LoadCurrentScene()
    {
        StartCoroutine(WaitandLoadCurrentScene());
    }

    IEnumerator WaitandLoadCurrentScene()
    {
        yield return new WaitForSeconds(delayInSeconds);

        SceneManager.LoadScene(sceneIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
