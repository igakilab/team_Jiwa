using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int killEnemyNum;//倒した敵の数
    public int score;

    public int stage;

    public static GameManager instance = null;
    Slider PlayerHPVar;
    Text PlayerHPText;
    Text ScoreText;
    Slider ExpBar;
    Text ExpText;
    Text finishText;
    Text healKeyText;

    bool showRanking = false;

    public Timer timer; //タイマーオブジェクト

    private GameObject PlayerObject;//プレイヤーオブジェクト

    PlayerController player;//プレイヤースクリプト

    Toggle RecoverToggle;

    [SerializeField]GameObject CenterTextObject;

    public messageLogController MessageLog;

    private bool game=false; //ゲームの有効無効

    private float startTime=3;
    private bool isTimeZero = false;

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
    
    private bool StartTimer()
    {
        int seconds;
        if (startTime > 0)
        {
            startTime -= Time.deltaTime;
            seconds = (int)startTime;
            CenterTextObject.GetComponent<Text>().text = seconds.ToString();
            if (startTime < 0)
            {
                startTime = 0;
                return true;
            }
            return false;
            
        }
        return true;
    }
    private void UICtrl()
    {
        PlayerHPText.text = player.status.getHP().ToString(); //プレイヤーの体力を随時更新
        PlayerHPVar.value = (float)player.status.getHP() / (float)player.status.getMaxHP();

        ExpText.text = string.Format("{0}/{1}", player.status.getExp(), player.status.getNeedExp());
        ExpBar.value = (float)player.status.getExp() / (float)player.status.getNeedExp();

        ScoreText.text = score.ToString();

        RecoverToggle.isOn = player.getRecover();

        healKeyText.text = Contoroller.ButtonText("回復");

        
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
        setGame(false);//ゲームの終了
        CenterTextObject.GetComponent<Text>().text = "Game Over";
        CenterTextObject.SetActive(true);//GameOverの表示
        finishText.gameObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0")) SceneManager.LoadScene("Title");
    }

    private IEnumerator PrintRanking()
    {
        showRanking = true;
        yield return new WaitForSeconds(3f);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score, stage);

        finishText.text = "-- Press " + Contoroller.ButtonText("決定") + "  to Title --";
        finishText.gameObject.SetActive(true);


    }

    private void GameClear()
    {
        setGame(false);//ゲームを終了させる

        CenterTextObject.GetComponent<Text>().text = "Game Clear";
        finishText.text = "-- Press " + Contoroller.ButtonText("決定") + "  to Title --";
        CenterTextObject.SetActive(true);

        if (!showRanking)
        {
            StartCoroutine(PrintRanking());
            
        }
        if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown("joystick button 0")) SceneManager.LoadScene("Title");
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player"); //プレイヤーオブジェクトを探す

        RecoverToggle = GameObject.Find("UI/recover").GetComponent<Toggle>();

        GameObject UI = GameObject.Find("UI");

        PlayerHPVar = GameObject.Find("UI/PlayerHP/HPvar").GetComponent<Slider>();
        PlayerHPText = GameObject.Find("UI/PlayerHP/HPText").GetComponent<Text>();
        ExpBar = GameObject.Find("UI/Exp/ExpBar").GetComponent<Slider>();
        ExpText = GameObject.Find("UI/Exp/ExpText").GetComponent<Text>();
        ScoreText = GameObject.Find("UI/ScoreText").GetComponent<Text>();
        finishText = UI.transform.Find("FinishText").GetComponent<Text>();
        healKeyText = GameObject.Find("UI/HealText").GetComponent<Text>();

        player = PlayerObject.GetComponent<PlayerController>();

        setGame(true);

        killEnemyNum = 0;
        score = 0;
        stage = stageSelector.stage;//選択したステージの所得
        CenterTextObject.SetActive(false);
        finishText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();

        if (timer.isTimeZero())
        {
            GameClear();

        }

        if(player.status.isDeath())
        {
            GameOver();
        }

    }
}
