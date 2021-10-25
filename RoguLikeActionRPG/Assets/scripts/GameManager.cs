using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    int EnemyNum; //�V�[�����̓G�̐�
    int killEnemyNum;//�|�����G�̐�
    GameObject Enemys;//�G�l�~�[�̐e�I�u�W�F�N�g

    public static GameManager instance = null;
    Slider PlayerHPVar;
    Text PlayerHPText;
    Slider ExpBar;
    Text ExpText;

    public float starttimer; //�^�C�}�[�̊J�n����

    public Timer timer; //�^�C�}�[�I�u�W�F�N�g

    private GameObject Player;
    PlayerStatusData PlayerStatus;//�v���C���[�̃X�e�[�^�X;

    public messageLogController MessageLog;

    private bool game=false; //�Q�[���̗L������

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
        PlayerHPText.text = PlayerStatus.getHP().ToString(); //�v���C���[�̗̑͂𐏎��X�V
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
        GameObject Enemy;//�X�|�[������G
        float SpawnX; //�X�|�[��������W
        int num;

        SpawnX = Random.Range(-10f, 10f);//�X�|�[��������W���w�肵���͈͓��Ń����_���œ���

        num = Random.Range(1, 100);

        if(num<=45)
        {
            Enemy = (GameObject)Resources.Load("Prefab/Enemy/suraimu");//�X�|�[���Ώۂ̃v���n�u��ǂݍ���
        }
        else if(num<=90)
        {
            Enemy = (GameObject)Resources.Load("Prefab/Enemy/goburin");//�X�|�[���Ώۂ̃v���n�u��ǂݍ���
        }
        else
        {
            Enemy = (GameObject)Resources.Load("Prefab/Enemy/gaikotu");//�X�|�[���Ώۂ̃v���n�u��ǂݍ���
        }

        Instantiate(Enemy, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//Enemys�̎q�I�u�W�F�N�g�Ƀv���n�u�𐶐�

    }

    private void spawnBoss()
    {
        GameObject Enemy;//�X�|�[������G
        float SpawnX; //�X�|�[��������W

        SpawnX = Random.Range(-10f, 10f);//�X�|�[��������W���w�肵���͈͓��Ń����_���œ���

        Enemy = (GameObject)Resources.Load("Prefab/Enemy/KingGoburin");

        Instantiate(Enemy, new Vector3(SpawnX, 0f, 0f), Quaternion.identity).transform.parent = Enemys.transform;//Enemys�̎q�I�u�W�F�N�g�Ƀv���n�u�𐶐�
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //�v���C���[�I�u�W�F�N�g��T��
        Enemys = GameObject.Find("Enemys");//�G���o������e�I�u�W�F�N�g

        PlayerHPVar = GameObject.Find("UI/PlayerHP/HPvar").GetComponent<Slider>();
        PlayerHPText = GameObject.Find("UI/PlayerHP/HPText").GetComponent<Text>();
        ExpBar = GameObject.Find("UI/Exp/ExpBar").GetComponent<Slider>();
        ExpText = GameObject.Find("UI/Exp/ExpText").GetComponent<Text>();

        PlayerStatus = Player.GetComponent<Warrior>().status; //warior���Q��

        setGame(true);

        killEnemyNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();

        if(timer.isTimeZero())
        {
            setGame(false);//�Q�[�����I��������
        }

        EnemyNum = Enemys.transform.childCount;//�G�̐��𐔂���

        //�V�[�����̓G���S�̈ȉ��Ȃ�
        if(EnemyNum<4)
        {
            spawnEnemey();//�X�|�[��
        }
        if(killEnemyNum%10==0 && !(killEnemyNum==0))
        {
            if(GameObject.FindGameObjectWithTag("Boss")==null)  spawnBoss();
        }

    }
}
