using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoroller : MonoBehaviour
{
    public static bool isConectedContoroller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var controllerNames = Input.GetJoystickNames();//接続されているコントローラの名前を調べる

        if(controllerNames[0]=="")
        {
            isConectedContoroller = false;
        }
        else
        {
            isConectedContoroller = true;
        }
    }
}
