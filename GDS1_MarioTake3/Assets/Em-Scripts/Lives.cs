using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT MUST REMAIN ENTACT IN ALL SCENES AFTER MENU SCREEN 

public class Lives : MonoBehaviour
{

    public int lives;
    LoadScene loadScene;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
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
}
