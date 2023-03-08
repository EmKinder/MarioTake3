using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   public int score;
    int coins;
    Text scoreText;
    Text coinsText;
    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        coins = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Canvas/ScoreText") != null)
        {
            scoreText = GameObject.Find("Canvas/ScoreText").GetComponent<Text>();
        }

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

        if (GameObject.Find("Canvas/CoinsText") != null)
        {
            coinsText = GameObject.Find("Canvas/CoinsText").GetComponent<Text>();
        }

        if (coinsText != null)
        {
            coinsText.text = coins.ToString();
        }
    }

    public void SetScore(int newScore)
    {
        score += newScore;
    }
    
    public void SetCoins()
    {
        coins++;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetCoins()
    {
        return coins;
    }
}
