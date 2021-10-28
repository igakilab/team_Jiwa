using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class StageImageDisplayer : MonoBehaviour
{
    public stageSelector st;
    private void Update()
    {
        
        GameObject image = transform.GetChild(0).gameObject;
        GameObject shader = transform.GetChild(1).gameObject;
        if(st.btn == image)
        {
            Debug.Log("corresponded. object name: " + st.btn.name);
            shader.SetActive(false);
        }
        else
        {
            Debug.Log("not corresponded.");
            shader.SetActive(true);
        }
    }

}
