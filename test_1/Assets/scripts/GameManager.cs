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

    public float StartTime; //�^�C�}�[�̊J�n�l;
    

    private void UICtrl()
    {
        PlayerHPText.text = PlayerStatus.getHP().ToString(); //�v���C���[�̗̑͂𐏎��X�V
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
        Player = GameObject.FindGameObjectWithTag("Player"); //�v���C���[�I�u�W�F�N�g��T��

        PlayerHPVar = GameObject.Find("UI/PlayerHP/HPvar").GetComponent<Slider>();
        PlayerHPText = GameObject.Find("UI/PlayerHP/HPText").GetComponent<Text>();
        TimerText = GameObject.Find("UI/TimerText").GetComponent<Text>();
        PlayerStatus = Player.GetComponent<Warrior>().status; //warior���Q��
        
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();
    }
}
