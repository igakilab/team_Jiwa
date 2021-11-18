using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : CharacterStatus
{

    private bool invincible = false;//無敵
    

    private int level;
    private int exp; //現在の所持経験値
    int needExp;//次のレベル上がるのに必要な経験値

    //コンストラクタ
    public PlayerStatus(PlayerStatusData data):base(data)
    {
        //プレイヤーの固有ステータスの初期化
        level = 1;
        exp = 0;
        needExp = 20;


        setInvicible(false);
        setDeath(false);
    }

    //ランダムでステータスを上げる
    void RandomStatusUp()
    {
        int Statusup = Random.Range(0, 3);//３つのステータスをランダム選択

        int UpValue = Random.Range(1, 4);//ステータスの上がり基礎値

        switch (Statusup)
        {
            //HP
            case 0:
                int addValueHP = UpValue * 4;//HPの場合は基礎値から*4した値を上げる
                GameManager.instance.MessageLog.enqueueMessage("HPが" + addValueHP + "上がった!");
                addMaxHP(addValueHP);
                addHP(addValueHP);
                break;
            //Atk
            case 1:
                GameManager.instance.MessageLog.enqueueMessage("攻撃力が" + UpValue + "上がった！");
                addAtk(UpValue);
                break;
            //Def
            case 2:
                GameManager.instance.MessageLog.enqueueMessage("防御力が" + UpValue + "上がった！");
                addDef(UpValue);
                break;
        }
    }

    public void levelup()
    {
        GameManager.instance.MessageLog.enqueueMessage("レベルが上がった！");
        level++;

        exp = exp - needExp;//経験値が越えた差分を代入
        needExp = (int)(needExp * 1.2f);

        RandomStatusUp();
    }

    public bool isInvicible()
    {
        return invincible;
    }

    public void setInvicible(bool tf)
    {
        invincible = tf;
    }

    //getter setter adder

    public int getExp()
    {
        return this.exp;
    }

    public int getNeedExp()
    {
        return this.needExp;
    }



    public void addExp(int value)
    {
        this.exp += value;
    }


}
