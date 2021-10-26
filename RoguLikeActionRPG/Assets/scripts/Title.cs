using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private bool isAlreadyPushedVKey = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V) && !isAlreadyPushedVKey)
        {
            isAlreadyPushedVKey = true;
            Debug.Log("pushed");
            SceneManager.LoadScene("StageSelect");
        }
        
    }
}
