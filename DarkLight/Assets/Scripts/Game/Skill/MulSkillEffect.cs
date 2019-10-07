using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulSkillEffect : MonoBehaviour {
    private MultiSkill skill;
    private List<GameObject> getDamage;

    public void Init(BaseSkill skill)
    {
        this.skill = skill as MultiSkill;
    }

    // Use this for initialization
    void Start () {
        getDamage = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag==Tags.enemy)
        {
            if (!getDamage.Contains(collision.gameObject))
            {
                collision.SendMessage("GetAttack", skill.SkillDamage);
                getDamage.Add(collision.gameObject);
            }
        }
    }
}
