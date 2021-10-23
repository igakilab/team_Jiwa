using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Text timerText;

    private float totalTime;
    int seconds;

    public bool isTimerZero()
    {
        if(totalTime==0)
        {
            return true;
        }

        return false;
    }

    void Start()
    {
        totalTime = GameManager.instance.StartTime;
        timerText = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(totalTime>0)
        {
            totalTime -= Time.deltaTime;
            seconds = (int)totalTime;
            if (totalTime < 0) totalTime = 0;
        }

        timerText.text = seconds.ToString();
    }
}
