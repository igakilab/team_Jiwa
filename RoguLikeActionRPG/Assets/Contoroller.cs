using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoroller : MonoBehaviour
{
    public static bool isConectedContoroller=false;

    string[] ControllerNames=new string[10];
    // Start is called before the first frame update
    void Start()
    {
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
