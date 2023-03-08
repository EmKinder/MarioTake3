using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButtons : MonoBehaviour
{
    LoadScene loadScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<LoadScene>() != null)
        {
            loadScene = FindObjectOfType<LoadScene>();
        }
    }

    public void QuitGame()
    {
        if(loadScene != null)
        {
            loadScene.QuitGame();
        }
    }

    public void RestartGame()
    {
        Debug.Log("ButtonClick");
        if(loadScene != null)
        {
            Debug.Log("GameRestart");
            loadScene.GameRestart();
        }
    }
}
