using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int killEnemyNum;//倒した敵の数

    public static GameManager instance = null;
    Slider PlayerHPVar;
    Text PlayerHPText;
    Slider ExpBar;
    Text ExpText;

    public float starttimer; //タイマーの開始時間

    public Timer timer; //タイマーオブジェクト

    private GameObject PlayerObject;//プレイヤーオブジェクト

    PlayerController player;//プレイヤースクリプト

    [SerializeField]GameObject GameOverObject;

    public messageLogController MessageLog;

    private bool game=false; //ゲームの有効無効

    public void addKillEnemy()
    {
        killEnemyNum++;
    }

    public int GetKillEnemy()
    {
        return killEnemyNum;
    }

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
        PlayerHPText.text = player.status.getHP().ToString(); //プレイヤーの体力を随時更新
        PlayerHPVar.value = (float)player.status.getHP() / (float)player.status.getMaxHP();

        ExpText.text = string.Format("{0}/{1}", player.status.getExp(), player.status.getNeedExp());
        ExpBar.value = (float)player.status.getExp() / (float)player.status.getNeedExp();

        
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

    private void GameOver()
    {
        GameOverObject.GetComponent<Text>().text = "Game Over";
        GameOverObject.SetActive(true);//GameOverの表示

        if (Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("Title");
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player"); //プレイヤーオブジェクトを探す

        PlayerHPVar = GameObject.Find("UI/PlayerHP/HPvar").GetComponent<Slider>();
        PlayerHPText = GameObject.Find("UI/PlayerHP/HPText").GetComponent<Text>();
        ExpBar = GameObject.Find("UI/Exp/ExpBar").GetComponent<Slider>();
        ExpText = GameObject.Find("UI/Exp/ExpText").GetComponent<Text>();

        player = PlayerObject.GetComponent<PlayerController>();

        setGame(true);

        killEnemyNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();

        if(timer.isTimeZero())
        {
            setGame(false);//ゲームを終了させる

            GameOverObject.GetComponent<Text>().text = "Game Clear";
            GameOverObject.SetActive(true);//GameOverの表示

            if (Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("Title");

        }

        if(player.status.isDeath())
        {
            GameOver();
        }

    }
}
