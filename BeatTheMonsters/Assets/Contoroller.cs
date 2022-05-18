using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoroller : MonoBehaviour
{
    public static bool isConectedContoroller=false;

    string[] ControllerNames=new string[10];
    // Start is called before the first frame update

    public static string ButtonText(string input)
    {
        string button="";

        if (isConectedContoroller)
        {
            switch (input)
            {
                case "決定":
                    button = "A"; 
                    break;
                case "戻る":
                    button = "B";
                    break;
                case "攻撃":
                    button = "X";
                    break;
                case "回復":
                    button = "B";
                    break;
                case "ジャンプ":
                    button = "A";
                    break;
                case "移動":
                    button = "Lスティック";
                    break;
                case "セレクト":
                    button = "Lスティック";
                    break;
            }

        }
        else
        {
            switch (input)
            {
                case "決定":
                    button = "Enter";
                    break;
                case "戻る":
                    button = "Escape";
                    break;
                case "攻撃":
                    button = "V or 左クリック";
                    break;
                case "回復":
                    button = "B";
                    break;
                case "ジャンプ":
                    button = "Space";
                    break;
                case "移動":
                    button = "A D";
                    break;
                case "セレクト":
                    button = "W A S D 矢印キー";
                    break;
            }
        }

        return button;
    }
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
        
       ControllerNames = Input.GetJoystickNames();//接続されているコントローラの名前を調べる



        if (ControllerNames.Length==0)
        {
            isConectedContoroller = false;
        }
        else
        {
            if(ControllerNames[0]=="")
            {
                isConectedContoroller = false;
            }
            else
            {
                isConectedContoroller = true;
            }
        }
    }
}
