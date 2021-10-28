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

    private Button prev_selected;

    void Start()
    {
        FirstSelectButton.Select();
        btn = EventSystem.current.currentSelectedGameObject;
    }

    public void OnClick(int number)
    {
        Debug.Log("go to stage " + number + "!");
        SceneManager.LoadScene("Stage" + number);
    }

    public void Update()
    {
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
