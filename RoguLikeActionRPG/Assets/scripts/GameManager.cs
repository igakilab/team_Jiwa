using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

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

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //�v���C���[�I�u�W�F�N�g��T��

        PlayerHPVar = GameObject.Find("UI/PlayerHP/HPvar").GetComponent<Slider>();
        PlayerHPText = GameObject.Find("UI/PlayerHP/HPText").GetComponent<Text>();
        ExpBar = GameObject.Find("UI/Exp/ExpBar").GetComponent<Slider>();
        ExpText = GameObject.Find("UI/Exp/ExpText").GetComponent<Text>();

        PlayerStatus = Player.GetComponent<Warrior>().status; //warior���Q��

        setGame(true);
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();

        if(timer.isTimeZero())
        {
            setGame(false);//�Q�[�����I��������
        }

        //Debug.Log("�Q�[����:" + isGame());

    }
}
