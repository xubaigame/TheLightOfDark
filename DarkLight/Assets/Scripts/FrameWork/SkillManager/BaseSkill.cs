using UnityEngine;

public class BaseSkill
{
    private int skillID;
    public int SkillID
    {
        get
        {
            return skillID;
        }

        set
        {
            skillID = value;
        }
    }

    private string skillName;
    public string SkillName
    {
        get
        {
            return skillName;
        }

        set
        {
            skillName = value;
        }
    }

    private string skillSprite;
    public string SkillSprite
    {
        get
        {
            return skillSprite;
        }

        set
        {
            skillSprite = value;
        }
    }

    private string skillDes;
    public string SkillDes
    {
        get
        {
            return skillDes;
        }

        set
        {
            skillDes = value;
        }
    }

    private SkillTypes skillType;
    public SkillTypes SkillType
    {
        get
        {
            return skillType;
        }

        set
        {
            skillType = value;
        }
    }

    private int skillMP;
    public int SkillMP
    {
        get
        {
            return skillMP;
        }

        set
        {
            skillMP = value;
        }
    }

    private int skillCD;
    public int SkillCD
    {
        get
        {
            return skillCD;
        }

        set
        {
            skillCD = value;
        }
    }

    private PlayerTypes playerType;
    public PlayerTypes PlayerType
    {
        get
        {
            return playerType;
        }

        set
        {
            playerType = value;
        }
    }

    private int playerLevel;
    public int PlayerLevel
    {
        get
        {
            return playerLevel;
        }

        set
        {
            playerLevel = value;
        }
    }

    private string effectPath;

    public string EffectPath
    {
        get
        {
            return effectPath;
        }

        set
        {
            effectPath = value;
        }
    }

    private string animName;
    public string AnimName
    {
        get
        {
            return animName;
        }

        set
        {
            animName = value;
        }
    }

    private double animTime;
    public double AnimTime
    {
        get
        {
            return animTime;
        }

        set
        {
            animTime = value;
        }
    }

    public virtual void UseSkill(Transform target)
    {

    }

    public virtual void Update()
    {

    }
}
