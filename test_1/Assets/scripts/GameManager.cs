using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    Slider PlayerHPVar;
    Text PlayerHPText;
    Text TimerText;

    private GameObject Player;
    PlayerStatusData PlayerStatus;

    public float StartTime; //タイマーの開始値;
    

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
        TimerText = GameObject.Find("UI/TimerText").GetComponent<Text>();
        PlayerStatus = Player.GetComponent<Warrior>().status; //wariorを参照
        
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();
    }
}
