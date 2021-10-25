using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    int EnemyNum; //シーン内の敵の数
    int killEnemyNum;//倒した敵の数
    GameObject Enemys;//エネミーの親オブジェクト

    public static GameManager instance = null;
    Slider PlayerHPVar;
    Text PlayerHPText;
    Slider ExpBar;
    Text ExpText;

    public float starttimer; //タイマーの開始時間

    public Timer timer; //タイマーオブジェクト

    private GameObject Player;
    PlayerStatusData PlayerStatus;//プレイヤーのステータス;

    public messageLogController MessageLog;

    private bool game=false; //ゲームの有効無効

    public void addKillEnemy()
    {
        killEnemyNum++;
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
        PlayerHPText.text = PlayerStatus.getHP().ToString(); //プレイヤーの体力を随時更新
        PlayerHPVar.value = (float)PlayerStatus.getHP() / (float)PlayerStatus.getMaxHP();

        ExpText.text = string.Format("{0}/{1}", PlayerStatus.getExp(), PlayerStatus.getNeedExp());
        ExpBar.value = (float)PlayerStatus.getExp() / (float)PlayerStatus.getNeedExp();

        
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

    private void spawnEnemey()
    {
        GameObject Enemy;//スポーンする敵
        float SpawnX; //スポーンする座標
        int num;

        SpawnX = Random.Range(-10f, 10f);//スポーンする座標を指定した範囲内でランダムで入手

        num = Random.Range(1, 100);

        if(num<=45)
        {
            Enemy = (GameObject)Resources.Load("Prefab/Enemy/suraimu");//スポーン対象のプレハブを読み込む
        }
        else if(num<=90)
        {
            Enemy = (GameObject)Resources.Load("Prefab/Enemy/goburin");//スポーン対象のプレハブを読み込む
        }
        else
        {
            Enemy = (GameObject)Resources.Load("Prefab/Enemy/gaikotu");//スポーン対象のプレハブを読み込む
        }

        Instantiate(Enemy, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//Enemysの子オブジェクトにプレハブを生成

    }

    private void spawnBoss()
    {
        GameObject Enemy;//スポーンする敵
        float SpawnX; //スポーンする座標

        SpawnX = Random.Range(-10f, 10f);//スポーンする座標を指定した範囲内でランダムで入手

        Enemy = (GameObject)Resources.Load("Prefab/Enemy/KingGoburin");

        Instantiate(Enemy, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//Enemysの子オブジェクトにプレハブを生成
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //プレイヤーオブジェクトを探す
        Enemys = GameObject.Find("Enemys");//敵が出現する親オブジェクト

        PlayerHPVar = GameObject.Find("UI/PlayerHP/HPvar").GetComponent<Slider>();
        PlayerHPText = GameObject.Find("UI/PlayerHP/HPText").GetComponent<Text>();
        ExpBar = GameObject.Find("UI/Exp/ExpBar").GetComponent<Slider>();
        ExpText = GameObject.Find("UI/Exp/ExpText").GetComponent<Text>();

        PlayerStatus = Player.GetComponent<Warrior>().status; //wariorを参照

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
        }

        EnemyNum = Enemys.transform.childCount;//敵の数を数える

        //シーン内の敵が４体以下なら
        if(EnemyNum<4)
        {
            spawnEnemey();//スポーン
        }
        if(killEnemyNum%10==0 && !(killEnemyNum==0))
        {
            if(GameObject.FindGameObjectWithTag("Boss")==null)  spawnBoss();
        }

    }
}
