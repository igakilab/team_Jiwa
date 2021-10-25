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
    private int exp; //現在の所持経験値
    int needExp;//次のレベル上がるのに必要な経験値

    public void showStatus()
    {
        Debug.Log("MaxHP:"+MaxHP);
        Debug.Log("HP:" + getHP());
        Debug.Log("Atk:" + atk);
        Debug.Log("Def:" + def);

        Debug.Log("必要経験値:" + needExp);
        Debug.Log("所持経験値:" + exp);
    }

    //ランダムでステータスを上げる
    void RandomStatusUp()
    {
        int Statusup = Random.Range(0, 3);//３つのステータスをランダム選択

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

    public void initialize()
    {
        level = 1;
        MaxHP = getInitMaxHP();
        setHP(getInitMaxHP());//
        atk = getInitAtk();
        def = getInitDef();
        needExp = 20;
        exp = 0;

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

    public int getExp()
    {
        return this.exp;
    }

    public int getNeedExp()
    {
        return this.needExp;
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

    public void addExp(int value)
    {
        this.exp += value;
    }


}
