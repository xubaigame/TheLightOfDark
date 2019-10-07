using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	 public void Death(EnemyTypes enemyType)
    {
        Destroy(this.gameObject, 2);
        EnemyManager.Instance.CreateOneEnemy(enemyType);
        if(enemyType==TaskManager.Instance.currentTask.EffectEnemyType)
        {
            TaskManager.Instance.GoingTask();
        }

    }
	// Update is called once per frame
	void Update () {
		
	}
}
