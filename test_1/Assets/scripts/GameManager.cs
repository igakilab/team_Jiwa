using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    Slider PlayerHPVar;
    Text PlayerHPText;

    private GameObject Player;
    PlayerStatusData PlayerStatus;
    

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

        PlayerHPVar = GameObject.Find("UI/PlayerHPvar").GetComponent<Slider>();
        PlayerHPText = GameObject.Find("UI/PlayerHPText").GetComponent<Text>();
        PlayerStatus = Player.GetComponent<Warrior>().status; //warior���Q��
        
    }

    // Update is called once per frame
    void Update()
    {
        UICtrl();
    }
}
