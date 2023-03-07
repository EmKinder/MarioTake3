using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadScene : MonoBehaviour
{
    public float timer;
    public bool timerActive;
    public int sceneIndex;


    // Start is called before the first frame update


    private void Start()
    {
        timerActive = false;
        timer = 0;
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
                    sceneIndex = 0;
                    SceneManager.LoadScene(0);
                    timerActive = false;
                    timer = 0;
                }
                if (SceneManager.GetActiveScene().buildIndex == 3)
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
        SceneManager.LoadScene(0);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(3);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        timerActive = true;
    }

    public bool TestTimerLength(float thisTimer)
    {
        return timer >= 3.0f;
    }

    public int GetSceneIndex()
    {
        return sceneIndex;
    }
}
