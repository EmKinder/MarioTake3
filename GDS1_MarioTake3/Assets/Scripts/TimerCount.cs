using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCount : MonoBehaviour
{
    public float timerCounter;
    public bool timerCounterOn = false;
    public Text timerText;
    public Text storeTimerText;
    private float tMinutes = 0;
    private float tSeconds = 0;
    private float tMSeconds = 0;
    // Start is called before the first frame update
    void Start()
    {
        timerCounterOn = true;
        timerText.text = tMinutes.ToString() + ":" + tSeconds.ToString() + ":" + tMSeconds.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (timerCounterOn)
        {
            if (timerCounter >= 0)
            {
                timerCounter = timerCounter + Time.deltaTime;
                timerCounter = timerCounter + 1 / 60;
                tMinutes = Mathf.Floor(timerCounter / 60);
                tSeconds = Mathf.Floor(timerCounter % 60);
                tMSeconds = Mathf.Floor((timerCounter - tSeconds) * 1000);
                timerText.text = tMinutes.ToString() + ":" + tSeconds.ToString() + ":" + tMSeconds.ToString();
            }
        }
    }
}
