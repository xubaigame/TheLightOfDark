using LitJson;
using System;
using System.Data;
using UnityEngine;

public class BuffSkill : BaseSkill
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

    private int skillTime;
    public int SkillTime
    {
        get
        {
            return skillTime;
        }

        set
        {
            skillTime = value;
        }
    }


    public BuffSkill(DataRow item)
    {
        SkillID = int.Parse(item["skill_id"].ToString());
        SkillName = item["skill_name"].ToString();
        SkillSprite = item["skill_spirit"].ToString();
        SkillDes = item["skill_description"].ToString();
        SkillType = (SkillTypes)Enum.Parse(typeof(SkillTypes), item["skill_type"].ToString());
        SkillEffectAttr = (SkillEffectAttrs)Enum.Parse(typeof(SkillEffectAttrs), item["skill_effect_attribute"].ToString());
        SkillEffectValuel= int.Parse(item["skill_effect_value"].ToString());
        SkillTime= int.Parse(item["skill_time"].ToString());
        SkillMP= int.Parse(item["skill_mp"].ToString());
        SkillCD= int.Parse(item["skill_cd"].ToString());
        PlayerType= (PlayerTypes)Enum.Parse(typeof(PlayerTypes), item["player_type"].ToString());
        PlayerLevel= int.Parse(item["player_level"].ToString());
        EffectPath= item["skill_effect_path"].ToString();
        AnimName= item["skill_annimation_name"].ToString();
        AnimTime= double.Parse(item["skill_annimation_time"].ToString());
    }
    public override void UseSkill(Transform target)
    {
        if (PlayerStatusManager.Instance.HaveMP(SkillMP))
        {
            PlayerAttack pa = target.GetComponent<PlayerAttack>();
            pa.PlayerState = AnimationStates.SkillAttack;
            pa.PlayAnim(AnimName, AnimTime, () => { GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().PlayerState = AnimationStates.Attack; });
            GameObject effect = Resources.Load<GameObject>(EffectPath);
            GameObject.Instantiate(effect, target.transform.position, Quaternion.identity);
            int Attack = 0, Defence = 0, Speed = 0;
            double AttackSpeed = 0;
            if (SkillEffectAttr == SkillEffectAttrs.Attack)
            {
                 Attack = SkillEffectValuel;
            }
            if (SkillEffectAttr == SkillEffectAttrs.Defence)
            {
                 Defence = SkillEffectValuel;
            }
            if (SkillEffectAttr == SkillEffectAttrs.Speed)
            {
                 Speed = SkillEffectValuel;
            }
            if (SkillEffectAttr == SkillEffectAttrs.AttackSpeed)
            {
                 AttackSpeed = SkillEffectValuel-0.2f;
            }
            PlayerStatusManager.Instance.CutMP(SkillMP);
            PlayerStatusManager.Instance.AddTotal(Attack, Defence, Speed, AttackSpeed);
            MainScenesManager.Instance.Play(SkillTime, () =>
             {
                 PlayerStatusManager.Instance.AddTotal(-Attack, -Defence, -Speed, -AttackSpeed);
             });
        }
    }
}
