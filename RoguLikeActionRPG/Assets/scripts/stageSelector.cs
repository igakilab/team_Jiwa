using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stageSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public Button FirstSelectButton;
    void Start()
    {
        FirstSelectButton.Select();
    }

    public void OnClick(int number)
    {
        Debug.Log("go to stage " + number + "!");
        SceneManager.LoadScene("Stage" + number);
    }
}
