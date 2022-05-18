using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

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

        switch(stageSelector.stage)
        {
            case 1:
                totalTime = CO.STAGE1_TIME;
                break;
            case 2:
                totalTime = CO.STAGE2_TIME;
                break;
            case 3:
                totalTime = CO.STAGE3_TIME;
                break;
            default:
                totalTime = 60;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(totalTime>0 && GameManager.instance.isGame())
        {
            totalTime -= Time.deltaTime;
            seconds = (int)totalTime;
            if (totalTime < 0) totalTime = 0;
            timerText.text = seconds.ToString();
        }

    }
}
