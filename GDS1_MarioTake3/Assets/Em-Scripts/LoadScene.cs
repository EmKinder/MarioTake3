using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLivesScene()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LoadMainGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {

    }

    public void LoadGameOverScene()
    {

    }
}
