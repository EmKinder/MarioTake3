using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//THIS SCRIPT MUST REMAIN ENTACT IN ALL SCENES AFTER MENU SCREEN 

public class Lives : MonoBehaviour
{
    static Lives instance;
    public int lives;
    public LoadScene loadScene;
    public bool playerDeath; //TEST
    Text livesText;
    Text scoreText;
    Score score; 
    

    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        lives = 3;
        playerDeath = false; //TEST
    }

    private void Update()
    {
        if (GameObject.Find("Canvas/LivesText") != null)
        {
            livesText = GameObject.Find("Canvas/LivesText").GetComponent<Text>();
        }

        if(livesText != null) { 
            livesText.text = lives.ToString();
         }

        if (playerDeath)
        {
            PlayerDeath();
            playerDeath = false;
            //TEST
        }

        if(loadScene.GetSceneIndex() == 1)
        {
            lives = 3;
        }
    }

    // Update is called once per frame
    public void AddLife()
    {
        lives++; 
    }

    public int getLives()
    {
        return lives; 
    }

    public void PlayerDeath()
    {
        lives -= 1; 
        if(lives == 0)
        {
            //Any animation that needs to happen
            loadScene.LoadGameOverScene();
        }
        else
        {
            //Any animation that needs to happen
            loadScene.LoadLivesScene();
        }
    }

    public void ResetLives()
    {
        lives = 3;
        if (livesText != null)
        {
            livesText.text = "3";
        }
    }
}
