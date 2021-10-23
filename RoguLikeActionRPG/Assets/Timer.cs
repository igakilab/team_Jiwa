using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    public float totalTime;
    int seconds;

    public bool isTimeZero()
    {
        if(totalTime==0)
        {
            return true;
        }
        return false;
    }


    // Start is called before the first frame update
    void Start()
    {
        timerText = this.gameObject.GetComponent<Text>();
        totalTime = GameManager.instance.starttimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(totalTime>0)
        {
            totalTime -= Time.deltaTime;
            seconds = (int)totalTime;
            if (totalTime < 0) totalTime = 0;
            timerText.text = seconds.ToString();
        }

    }
}
