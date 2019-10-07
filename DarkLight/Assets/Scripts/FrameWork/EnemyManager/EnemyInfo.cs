using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo
{
    private int enemyID;
    public int EnemyID
    {
        get
        {
            return enemyID;
        }

        set
        {
            enemyID = value;
        }
    }
    private EnemyTypes enemyType;
    public EnemyTypes EnemyType
    {
        get
        {
            return enemyType;
        }

        set
        {
            enemyType = value;
        }
    }

    private string enemyName;
    public string EnemyName
    {
        get
        {
            return enemyName;
        }

        set
        {
            enemyName = value;
        }
    }

    private int hp;
    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    private int exp;
    public int Exp
    {
        get
        {
            return exp;
        }

        set
        {
            exp = value;
        }
    }

    private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }
    private int leaveDistance;
    public int LeaveDistance
    {
        get
        {
            return leaveDistance;
        }

        set
        {
            leaveDistance = value;
        }
    }

    private double missPrecent;
    public double MissPrecent
    {
        get
        {
            return missPrecent;
        }

        set
        {
            missPrecent = value;
        } 
    }

    private int moveSpeed;
    public int MoveSpeed
    {
        get
        {
            return moveSpeed;
        }

        set
        {
            moveSpeed = value;
        }
    }

    private int attackSpeed;
    public int AttackSpeed
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

    private int minAttackDistance;
    public int MinAttackDistance
    {
        get
        {
            return minAttackDistance;
        }

        set
        {
            minAttackDistance = value;
        }
    }

    private double attackAnimTime;
    public double AttackAnimTime
    {
        get
        {
            return attackAnimTime;
        }

        set
        {
            attackAnimTime = value;
        }
    }
}
