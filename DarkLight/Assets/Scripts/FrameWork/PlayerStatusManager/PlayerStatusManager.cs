using FairyGUI;
using LitJson;
using System;
using System.IO;
using UnityEngine;

public class PlayerStatusManager : SingLeton<PlayerStatusManager> {
    #region 数据成员
    public PlayerStatusInfo playerInfo;

    PlayerInfoDAL playerInfoDAL = new PlayerInfoDAL();
    //装备属性
    private int attack = 0;

    private int defence=0;

    private int speed=0;

    private double attackSpeed = 0;
    public int Attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    public int Defence
    {
        get
        {
            return defence;
        }

        set
        {
            defence = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public double AttackSpeed
    {
        get
        {
            return attackSpeed;
        }

        set
        {
            attackSpeed = value;
        }
    }
    #endregion

    #region 事件
    //UI更新事件
    public Action UpdateUI;

    public Action LvUP;

    public Action Death;
    #endregion
    /// <summary>
    /// 初始化函数,加载角色状态信息
    /// </summary>
    public void Init()
    {
        LoadPlayerInfo();
    }

    /// <summary>
    /// 加载角色状态
    /// </summary>
    public void LoadPlayerInfo()
    {
        playerInfo = playerInfoDAL.LoadPlayerStatusInfo();
    }

    /// <summary>
    /// 保存角色状态信息
    /// </summary>
    public void SavePlayerStatusInfo()
    {
        playerInfoDAL.SavePlayerStatusInfo(playerInfo);
    }

    /// <summary>
    /// 增加金钱
    /// </summary>
    /// <param name="count"></param>
    public void AddMoney(int count)
    {
        playerInfo.Money += count;
        StartUpdateUI();
    }

    /// <summary>
    /// 判断金钱是否充足
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public bool HaveMoney(int count)
    {
        if (playerInfo.Money >= count)
            return true;
        return false;
    }

    /// <summary>
    /// 减少金钱
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public bool CutMoney(int count)
    {
        if (playerInfo.Money >= count)
        {
            playerInfo.Money -= count;
            StartUpdateUI();
            return true;
        }
        return false;
    }
    /// <summary>
    /// 调用事件
    /// </summary>
    public void StartUpdateUI()
    {
        if (UpdateUI != null)
            UpdateUI();
    }

    /// <summary>
    /// 调用事件
    /// </summary>
    public void StarLvUP()
    {
        if (LvUP != null)
        {
            LvUP();
        }
    }
    /// <summary>
    /// 调用事件
    /// </summary>
    public void StarDeath()
    {
        if (Death != null)
        {
            Death();
        }
    }
    /// <summary>
    /// 计算攻击力
    /// </summary>
    /// <returns>攻击力</returns>
    public int GetAttack()
    {
       return (playerInfo.Attack + playerInfo.Attack_Add+Attack);
    }

    /// <summary>
    /// 计算防御力
    /// </summary>
    /// <returns>防御力</returns>
    public string GetDefence()
    {
        return (playerInfo.Def + playerInfo.Def_Add+Defence).ToString();
    }
    /// <summary>
    /// 计算移动速度
    /// </summary>
    /// <returns>移动速度</returns>
    public string GetSpeed()
    {
        return (playerInfo.Speed + playerInfo.Speed_Add+Speed).ToString();
    }
    /// <summary>
    /// 计算战斗力
    /// </summary>
    /// <returns>战斗力</returns>
    public string GetTotal()
    {
        //战斗力计算公式:攻击力*10+防御力*5+移动速度*2;
        string Total = ((playerInfo.Attack + playerInfo.Attack_Add) * 10 + (playerInfo.Def+ playerInfo.Def_Add)*5 + (playerInfo.Speed+ playerInfo.Speed_Add)).ToString();
        return Total;
    }
    public int GetAttackDistance()
    {
        return playerInfo.AttackDistance;
    }
    public Double GetAttackSpeed()
    {
        return playerInfo.AttackSpeed+AttackSpeed;
    }
    /// <summary>
    /// 增加战斗力
    /// </summary>
    /// <param name="attack">增加的攻击力</param>
    /// <param name="defence">增加的防御力</param>
    /// <param name="speed">增加的移动速度</param>
    public void AddTotal(int attack,int defence,int speed,double attackSpeed)
    {
        AddAttack(attack);
        AddDefence(defence);
        AddSpeed(speed);
        AddAttackSpeed(attackSpeed);
        
        StartUpdateUI();
    }
    /// <summary>
    /// 增加战斗力
    /// </summary>
    public void AddAttack(int count)
    {
        Attack += count;
    }
    /// <summary>
    /// 增加防御力
    /// </summary>
    public void AddDefence(int count)
    {
        Defence += count;
    }
    /// <summary>
    /// 增加移动速度
    /// </summary>
    public void AddSpeed(int count)
    {
        Speed += count;
    }
    public void AddAttackSpeed(double count)
    {
        AttackSpeed -= count;
    }
    public void AddHP_MP(int hp,int mp)
    {
        AddHP(hp);
        AddMP(mp);
        StartUpdateUI();
    }
    public void AddHP(int hp)
    {
        playerInfo.Hp_Remain += hp;
        if (playerInfo.Hp_Remain > playerInfo.Hp)
            playerInfo.Hp_Remain = playerInfo.Hp;
    }
    public void AddMP(int mp)
    {
        playerInfo.Mp_Remain += mp;
        if (playerInfo.Mp_Remain > playerInfo.Mp)
            playerInfo.Mp_Remain = playerInfo.Mp;
    }
    /// <summary>
    /// 判断金钱是否充足
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public bool HaveMP(int mp)
    {
        if (playerInfo.Mp_Remain >= mp)
            return true;
        return false;
    }

    /// <summary>
    /// 减少金钱
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public bool CutMP(int mp)
    {
        if (playerInfo.Mp_Remain >= mp)
        {
            playerInfo.Mp_Remain -= mp;
            StartUpdateUI();
            return true;
        }
        return false;
    }
    public bool TakeDamage(int hp)
    {
        playerInfo.Hp_Remain -= hp;
        if (playerInfo.Hp_Remain <=0)
        {
            playerInfo.Hp_Remain = 0;
            StartUpdateUI();
            StarDeath();
            return false;
        }
        StartUpdateUI();
        return true;
    }
    public void AddExp(int exp)
    {
        playerInfo.ReMain_EXP += exp;
        if(playerInfo.ReMain_EXP > playerInfo.Exp)
        {
            playerInfo.ReMain_EXP -= playerInfo.Exp;
            playerInfo.Lv++;
            StarLvUP();
            playerInfoDAL.LVUpdate(playerInfo);
            
        }
        StartUpdateUI();
    }
    public double GetHpPrecent()
    {
        return (playerInfo.Hp_Remain / playerInfo.Hp) * 100;
    }
    public double GetMpPrecent()
    {
        return ((playerInfo.Mp_Remain) / playerInfo.Mp) * 100;
    }
    public double GetExpPrecent()
    {
        return (playerInfo.ReMain_EXP) /(double)playerInfo.Exp*100;
    }
    public void OnAttackButtonDown()
    {
        playerInfo.Attack_Add++;
        playerInfo.RemainPoint--;
        StartUpdateUI();
    }
    public void OnDefButtonDown()
    {
        playerInfo.Def_Add++;
        playerInfo.RemainPoint--;
        StartUpdateUI();
    }
    public void OnSpeedButtonDown()
    {
        playerInfo.Speed_Add++;
        playerInfo.RemainPoint--;
        StartUpdateUI();
    }

   
}
