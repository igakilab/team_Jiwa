using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    private GameObject stageButtons;
    
    public void onStartButtonClick()
    {
        //stageButtons.SetActive(true);
    }

    public void onStageButton(int stageNum)
    {
        switch(stageNum)
        {
            case 1:
                Debug.Log("�X�e�[�W1");
                break;
            case 2:
                Debug.Log("�X�e�[�W2");
                break;
            case 3:
                Debug.Log("�X�e�[�W3");
                break;
        }

    }

    void Start()
    {
        stageButtons = GameObject.Find("StageButtons");
    }
}
