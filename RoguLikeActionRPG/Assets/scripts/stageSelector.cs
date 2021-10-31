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

    public static int stage=0;//初期値テストステージ

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
            InstructText.text = "Lスティック：ステージ変更\nAボタン：ステージ決定";
        }
        else
        {
            InstructText.text = "WASDもしくは↑↓→←キー：ステージ変更\nEnterキーもしくはSpaceキー：ステージ決定";
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
