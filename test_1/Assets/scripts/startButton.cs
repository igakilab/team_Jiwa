using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour
{
    private bool isAlreadyPushed = false;
   

    public void PressStart()
    {
        if (!isAlreadyPushed)
        {
            Debug.Log("Strat Button Pushed.");
            isAlreadyPushed = true;
            //-------------�������玟�̃V�[���֔�ԏ���-----------------

            //-------------�����܂Ŏ��̃V�[���֔�ԏ���-----------------


        }
    }
}
