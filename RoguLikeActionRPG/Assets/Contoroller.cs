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
                case "����":
                    button = "A"; 
                    break;
                case "�߂�":
                    button = "B";
                    break;
                case "�U��":
                    button = "X";
                    break;
                case "��":
                    button = "B";
                    break;
                case "�W�����v":
                    button = "A";
                    break;
                case "�ړ�":
                    button = "L�X�e�B�b�N";
                    break;
                case "�Z���N�g":
                    button = "L�X�e�B�b�N";
                    break;
            }

        }
        else
        {
            switch (input)
            {
                case "����":
                    button = "Enter";
                    break;
                case "�߂�":
                    button = "Escape";
                    break;
                case "�U��":
                    button = "V or ���N���b�N";
                    break;
                case "��":
                    button = "B";
                    break;
                case "�W�����v":
                    button = "Space";
                    break;
                case "�ړ�":
                    button = "A D";
                    break;
                case "�Z���N�g":
                    button = "W A S D ���L�[";
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
        
        
       ControllerNames = Input.GetJoystickNames();//�ڑ�����Ă���R���g���[���̖��O�𒲂ׂ�



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
