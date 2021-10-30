using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int killEnemyNum;//�|�����G�̐�
    public int score;

    public int stage;

    public static GameManager instance = null;
    Slider PlayerHPVar;
    Text PlayerHPText;
    Text ScoreText;
    Slider ExpBar;
    Text ExpText;

    bool showRanking = false;

    public float starttimer; //�^�C�}�[�̊J�n����

    public Timer timer; //�^�C�}�[�I�u�W�F�N�g

    private GameObject PlayerObject;//�v���C���[�I�u�W�F�N�g

    PlayerController player;//�v���C���[�X�N���v�g

    [SerializeField]GameObject GameOverObject;

    public messageLogController MessageLog;

    private bool game=false; //�Q�[���̗L������

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
        PlayerHPText.text = player.status.getHP().ToString(); //�v���C���[�̗̑͂𐏎��X�V
        PlayerHPVar.value = (float)player.status.getHP() / (float)player.status.getMaxHP();

        ExpText.text = string.Format("{0}/{1}", player.status.getExp(), player.status.getNeedExp());
        ExpBar.value = (float)player.status.getExp() / (float)player.status.getNeedExp();

        ScoreText.text = score.ToString();

        
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
        GameOverObject.SetActive(true);//GameOver�̕\��
           

        if (Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("Title");
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player"); //�v���C���[�I�u�W�F�N�g��T��

        PlayerHPVar = GameObject.Find("UI/PlayerHP/HPvar").GetComponent<Slider>();
        PlayerHPText = GameObject.Find("UI/PlayerHP/HPText").GetComponent<Text>();
        ExpBar = GameObject.Find("UI/Exp/ExpBar").GetComponent<Slider>();
        ExpText = GameObject.Find("UI/Exp/ExpText").GetComponent<Text>();
        ScoreText = GameObject.Find("UI/ScoreText").GetComponent<Text>();

        player = PlayerObject.GetComponent<PlayerController>();

        setGame(true);

        killEnemyNum = 0;
        score = 0;
        stage = stageSelector.stage;//�I�������X�e�[�W�̏���
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();

        if (timer.isTimeZero() || Input.GetKeyDown(KeyCode.O))
        {
            setGame(false);//�Q�[�����I��������

            GameOverObject.GetComponent<Text>().text = "Game Clear";
            GameOverObject.SetActive(true);//GameOver�̕\��

            if (!showRanking)
            {
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score, stage);
                showRanking = true;
            }

            if (Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("Title");

        }

        if(player.status.isDeath())
        {
            GameOver();
        }

    }
}
