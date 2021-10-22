using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    private GameObject stageButtons;
    private GameObject StartButton;
    
    public void onStartButtonClick()
    {
        stageButtons.SetActive(true);
        StartButton.SetActive(false);
        
    }

    public void onStageButton(int stageNum)
    {
        switch(stageNum)
        {
            case 1:
                Debug.Log("�X�e�[�W1");
                SceneManager.LoadScene("GameScene");
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
        StartButton = GameObject.Find("StartButton");

        stageButtons.SetActive(false);
    }
}
