using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public float totalTimer;

    Slider PlayerHPVar; //�v���C���[HPvar 
    Text PlayerHPText;
    Text TimerText; //�^�C�}�[�e�L�X�g


    private GameObject Player; //�v���C���[�I�u�W�F�N�g
    PlayerStatusData PlayerStatus; //�v���C���[�X�e�[�^�X���Q��

    private void Timer()
    {
        int seconds;
        totalTimer -= Time.deltaTime;
        seconds = (int)totalTimer;
        TimerText.text = seconds.ToString();
    }

    private void PlayerHPonUI()
    {
        PlayerHPText.text = PlayerStatus.getHP().ToString(); //�v���C���[�̗̑͂𐏎��X�V
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
        Player = GameObject.FindGameObjectWithTag("Player"); //�v���C���[�I�u�W�F�N�g��T��

        PlayerHPVar = GameObject.Find("UI/PlayerHP/HPvar").GetComponent<Slider>();
        PlayerHPText = GameObject.Find("UI/PlayerHP/HPText").GetComponent<Text>();
        PlayerStatus = Player.GetComponent<Warrior>().status; //warior���Q��
        
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();
    }
}
