using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    Slider PlayerHPVar;
    Text PlayerHPText;

    public float starttimer; //タイマーの開始時間

    public Timer timer; //タイマーオブジェクト

    private GameObject Player;
    PlayerStatusData PlayerStatus;//プレイヤーのステータス;

    public messageLogController MessageLog;

    private bool game=false; //ゲームの有効無効

    public void setGame(bool tf)
    {
        this.game = tf;
    }

    public bool isGame()
    {
        return this.game;
    }
    

    private void UICtrl()
    {
        PlayerHPText.text = PlayerStatus.getHP().ToString(); //プレイヤーの体力を随時更新
        PlayerHPVar.value = (float)PlayerStatus.getHP() / (float)PlayerStatus.getMaxHP();
    }

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
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

        setGame(true);
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();

        if(timer.isTimeZero())
        {
            setGame(false);//ゲームを終了させる
        }

        Debug.Log("ゲーム状況:" + isGame());

    }
}
