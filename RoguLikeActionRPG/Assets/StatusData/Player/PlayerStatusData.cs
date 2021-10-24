using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatusData : CharacterStatus
{
    private bool invincible = false; //無敵

    private int MaxHP; //現在の最大体力
    private int atk; //現在の攻撃力
    private int def; //現在の防御力

    private int level=1;
    private int exp; //
    int needExp;

    public void showStatus()
    {
        Debug.Log("MaxHP:"+MaxHP);
        Debug.Log("HP:" + getHP());
        Debug.Log("Atk:" + atk);
        Debug.Log("Def:" + def);
    }

    //ランダムでステータスを上げる
    void RandomStatusUp()
    {
        int Statusup = Random.Range(0, 3);

        int UpValue = Random.Range(1, 4);//ステータスの上がり基礎値

        switch(Statusup)
        {
            //HP
            case 0:
                int addValueHP=UpValue*4;//HPの場合は基礎値から*4した値を上げる
                GameManager.instance.MessageLog.enqueueMessage("HPが"+addValueHP+"上がった!");
                addMaxHP(addValueHP);
                addHP(addValueHP);
                break;
            //Atk
            case 1:
                GameManager.instance.MessageLog.enqueueMessage("攻撃力が"+UpValue+"上がった！");
                addAtk(UpValue);
                break;
            //Def
            case 2:
                GameManager.instance.MessageLog.enqueueMessage("防御力が"+UpValue+"上がった！");
                addDef(UpValue);
                break;
        }
    }

    public void levelup()
    {
        GameManager.instance.MessageLog.enqueueMessage("レベルが上がった！");
        level++;
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

    public void initialize()
    {
        level = 1;
        MaxHP = getInitMaxHP();
        setHP(getInitMaxHP());//
        atk = getInitAtk();
        def = getInitDef();

        setInvicible(false);
    }

    //getter setter adder
    public int getMaxHP()
    {
        return this.MaxHP;
    }

    public int getAtk()
    {
        return this.atk;
    }

    public int getDef()
    {
        return this.def;
    }

    public void addMaxHP(int value)
    {
        this.MaxHP += value;
    }

    public void addAtk(int value)
    {
        this.atk += value;
    }

    public void addDef(int value)
    {
        this.def += value;
    }


}
