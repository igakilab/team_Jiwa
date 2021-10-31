using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleControll : MonoBehaviour
{
    //表示しているテキストを管理
    public Text txt;

    //テキストの点滅や背景スライドショーの時間を管理
    public float speed = 1.0f;
    private float time1,time2;


    //Vキーが押されたらシーン移動するので，Vキーが押されたか確認するためのフラグ
    private bool isAlreadyPushedVKey = false;


    public float imageChangeTimer;
    public List<GameObject> images;
    public float fadeDelta;
    private int idx, nextIdx;
    private bool isFading;


    private void Start()
    {
        idx = 0;
        nextIdx = (idx + 1) % 3;
        

        time2 = imageChangeTimer;

        images[1].SetActive(false);
        images[2].SetActive(false);
        images[1].GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,0.0f);
        images[2].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        isFading = false;
        imagesChange();

    }
    // Update is called once per frame
    void Update()
    {
        textAlphaUpdate();
        imagesChange();

        //コントローラーの接続状況によってテキスト変更
        if (Contoroller.isConectedContoroller)
            txt.text = "- Press A key -";
        else
            txt.text = "- Press V key -";

        if ((Input.GetKeyDown(KeyCode.V)||Input.GetKeyDown("joystick button 0"))&& !isAlreadyPushedVKey)
        {
            isAlreadyPushedVKey = true;
            Debug.Log("pushed");
            SoundManager.PlaySelectSound();
            SceneManager.LoadScene("StageSelect");
        }
        
    }

    Color GetAlphaColor(Color color)
    {
        time1 += Time.deltaTime * 5.0f * speed;
        color.a = 0.5f * Mathf.Sin(time1) + 0.5f;

        return color;
    }

    void textAlphaUpdate()
    {
        txt.color = GetAlphaColor(txt.color);
        return;
    }

    void imagesChange()
    {
        
        if (!isFading)
        {
            time2 -= Time.deltaTime;
        }
        if(isFading || time2 <= 0.0f)
        {
            isFading = true;
            
            images[idx].SetActive(true);
            images[nextIdx].SetActive(true);

            if (images[idx].GetComponent<Image>().color.a > 0.00f)
            {
                float nowImageAlpha = images[idx].GetComponent<Image>().color.a;
                float nextImageAlpha = images[nextIdx].GetComponent<Image>().color.a;
                images[idx].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, nowImageAlpha - fadeDelta);
                images[nextIdx].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, nextImageAlpha + fadeDelta);
            }
            else
            {
                images[idx].SetActive(false);
                isFading = false;
                time2 = imageChangeTimer;
                idx = nextIdx;
                nextIdx = ++nextIdx % 3;
            }
        }
        
    }
   
}
