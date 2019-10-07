using LitJson;
using System;
using System.Data;
using UnityEngine;

public class PassiveSkill : BaseSkill
{
    private SkillEffectAttrs skillEffectAttr;
    public SkillEffectAttrs SkillEffectAttr
    {
        get
        {
            return skillEffectAttr;
        }

        set
        {
            skillEffectAttr = value;
        }
    }

    private int skillEffectValuel;
    public int SkillEffectValuel
    {
        get
        {
            return skillEffectValuel;
        }

        set
        {
            skillEffectValuel = value;
        }
    }

    public PassiveSkill(DataRow item)
    {
        SkillID = int.Parse(item["skill_id"].ToString());
        SkillName = item["skill_name"].ToString();
        SkillSprite = item["skill_spirit"].ToString();
        SkillDes = item["skill_description"].ToString();
        SkillType = (SkillTypes)Enum.Parse(typeof(SkillTypes), item["skill_type"].ToString());
        SkillEffectAttr = (SkillEffectAttrs)Enum.Parse(typeof(SkillEffectAttrs), item["skill_effect_attribute"].ToString());
        SkillEffectValuel = int.Parse(item["skill_effect_value"].ToString());
        SkillMP = int.Parse(item["skill_mp"].ToString());
        SkillCD = int.Parse(item["skill_cd"].ToString());
        PlayerType = (PlayerTypes)Enum.Parse(typeof(PlayerTypes), item["player_type"].ToString());
        PlayerLevel = int.Parse(item["player_level"].ToString());
        EffectPath = item["skill_effect_path"].ToString();
        AnimName = item["skill_annimation_name"].ToString();
        AnimTime = double.Parse(item["skill_annimation_time"].ToString());
    }
    public override void UseSkill(Transform target)
    {
        if(PlayerStatusManager.Instance.HaveMP(SkillMP))
        {
            PlayerAttack pa = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
            pa.PlayerState = AnimationStates.SkillAttack;
            pa.PlayAnim(AnimName,AnimTime,()=> { GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().PlayerState = AnimationStates.Attack; });
            GameObject effect = Resources.Load<GameObject>(EffectPath);
            GameObject.Instantiate(effect, target.transform.position, Quaternion.identity);
            int hp = 0, mp = 0;
            if (SkillEffectAttr == SkillEffectAttrs.HP)
                hp = SkillEffectValuel;
            if (SkillEffectAttr == SkillEffectAttrs.MP)
                mp = SkillEffectValuel;
            PlayerStatusManager.Instance.CutMP(SkillMP);
            PlayerStatusManager.Instance.AddHP_MP(hp, mp);
            
        }
    }
}
