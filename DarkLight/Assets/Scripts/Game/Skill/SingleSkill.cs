using LitJson;
using System;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;

public class SingleSkill : BaseSkill
{
    private int skillDis;
    public int SkillDis
    {
        get
        {
            return skillDis;
        }

        set
        {
            skillDis = value;
        }
    }
    private int skillDamage;
    public int SkillDamage
    {
        get
        {
            return skillDamage;
        }

        set
        {
            skillDamage = value;
        }
    }

    public SingleSkill(DataRow item)
    {
        SkillID = int.Parse(item["skill_id"].ToString());
        SkillName = item["skill_name"].ToString();
        SkillSprite = item["skill_spirit"].ToString();
        SkillDes = item["skill_description"].ToString();
        SkillType = (SkillTypes)Enum.Parse(typeof(SkillTypes), item["skill_type"].ToString());
        SkillMP = int.Parse(item["skill_mp"].ToString());
        SkillCD = int.Parse(item["skill_cd"].ToString());
        PlayerType = (PlayerTypes)Enum.Parse(typeof(PlayerTypes), item["player_type"].ToString());
        PlayerLevel = int.Parse(item["player_level"].ToString());
        EffectPath = item["skill_effect_path"].ToString();
        AnimName = item["skill_annimation_name"].ToString();
        AnimTime = double.Parse(item["skill_annimation_time"].ToString());
        SkillDamage = int.Parse(item["skill_damage"].ToString());
        SkillDis = int.Parse(item["skill_distance"].ToString());
    }
    public override void UseSkill(Transform target)
    {
        if (PlayerStatusManager.Instance.HaveMP(SkillMP))
        {
            MouseCursorManager.Instance.SetMouseCorsor(MouseCursorTypes.LockTarget);
            target.GetComponent<PlayerAttack>().SetState(SkillManager.Instance.GetsKillByID(SkillID));
        }
    }

}
