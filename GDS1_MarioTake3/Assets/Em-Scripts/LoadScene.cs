using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadScene : MonoBehaviour
{
    public float timer;
    public bool timerActive;
    public int sceneIndex;
    public bool gameReset;
    public Lives lives;
    public Score score;
    public AudioSource audio;
    public AudioClip gameOver;



    // Start is called before the first frame update


    private void Start()
    {
        timerActive = false;
        timer = 0;
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timer += Time.deltaTime;

            if (TestTimerLength(timer))
            {
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    sceneIndex = 1;
                    SceneManager.LoadScene(1);
                    timerActive = false;
                    timer = 0;
                }
            }
        }
    }
    
    
    public void LoadLivesScene()
    {
        SceneManager.LoadScene(2);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        timerActive = true;
    }
    
    public void LoadMainGame()
    {
        if(gameReset == true)
        {
            lives.ResetLives();
            
        }
        SceneManager.LoadScene(1);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadMainMenu()
    {
        GameRestart();
        SceneManager.LoadScene(0);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(3);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        audio.clip = gameOver;
        audio.Play();

    }

    public bool TestTimerLength(float thisTimer)
    {
        return timer >= 3.0f;
    }

    public int GetSceneIndex()
    {
        return sceneIndex;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameRestart()
    {
        lives.ResetLives();
        score.ResetScore();
        LoadLivesScene();
    }
}
