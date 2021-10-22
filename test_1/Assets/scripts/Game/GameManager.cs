using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public float totalTimer;

    Slider PlayerHPVar; //プレイヤーHPvar 
    Text PlayerHPText;
    Text TimerText; //タイマーテキスト


    private GameObject Player; //プレイヤーオブジェクト
    PlayerStatusData PlayerStatus; //プレイヤーステータスを参照

    private void Timer()
    {
        int seconds;
        totalTimer -= Time.deltaTime;
        seconds = (int)totalTimer;
        TimerText.text = seconds.ToString();
    }

    private void PlayerHPonUI()
    {
        PlayerHPText.text = PlayerStatus.getHP().ToString(); //プレイヤーの体力を随時更新
        PlayerHPVar.value = (float)PlayerStatus.getHP() / (float)PlayerStatus.getMaxHP();
    }

    private void UICtrl()
    {
        PlayerHPonUI();
        //Timer();
    }

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //プレイヤーオブジェクトを探す

        PlayerHPVar = GameObject.Find("UI/PlayerHP/HPvar").GetComponent<Slider>();
        PlayerHPText = GameObject.Find("UI/PlayerHP/HPText").GetComponent<Text>();
        PlayerStatus = Player.GetComponent<Warrior>().status; //wariorを参照
        
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();
    }
}
