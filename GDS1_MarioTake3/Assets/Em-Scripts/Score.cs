using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score;
    int coins;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
