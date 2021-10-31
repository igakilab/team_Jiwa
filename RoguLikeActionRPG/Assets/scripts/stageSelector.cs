using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class stageSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public Button FirstSelectButton;
    public GameObject btn;

    public static int stage=0;//�����l�e�X�g�X�e�[�W

    private Button prev_selected;

    public Text InstructText;

    void Start()
    {
        FirstSelectButton.Select();
        btn = EventSystem.current.currentSelectedGameObject;
    }



    public void OnClick(int number)
    {
        Debug.Log("go to stage " + number + "!");
        stage = number;
        SoundManager.PlaySelectSound();
        SceneManager.LoadScene("load");
        
    }

    public void Update()
    {
        if(Contoroller.isConectedContoroller)
        {
            InstructText.text = "L�X�e�B�b�N�F�X�e�[�W�ύX\nA�{�^���F�X�e�[�W����";
        }
        else
        {
            InstructText.text = "WASD�������́��������L�[�F�X�e�[�W�ύX\nEnter�L�[��������Space�L�[�F�X�e�[�W����";
        }


        btn = EventSystem.current.currentSelectedGameObject;
        if(btn == null)
        {
            prev_selected.Select();
        }
        else
        {
            prev_selected = btn.GetComponent<Button>();
        }
    }
}
