using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundController : MonoBehaviour
{
    public Image image;
    public Sprite[] sprits;
    public stageSelector st;

    // Start is called before the first frame update
    void Start()
    {
        image.sprite = sprits[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(st.btn != null)
        {
            switch (st.btn.name)
            {
                case "StageButton1":
                    image.sprite = sprits[0];
                    break;
                case "StageButton2":
                    image.sprite = sprits[1];
                    break;
                case "StageButton3":
                    image.sprite = sprits[2];
                    break;
                default:
                    break;
            }
        }
    }
}
