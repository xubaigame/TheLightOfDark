using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using MySql.Data.MySqlClient;
public class EnemyManager : SingLeton<EnemyManager> {

    private List<EnemyInfo> enemyInfoList;
    private List<EnemyBirthInfo> enemyBirthInfoList;
    private List<GameObject> enemyGameObject;
    public void Init()
    {
        enemyInfoList = new List<EnemyInfo>();
        enemyGameObject = new List<GameObject>();
        enemyBirthInfoList = new List<EnemyBirthInfo>();
        GetEnemyInfoList();
        GetEnemyBirthInfoList();
        CreateEnemy();
    }
    private void GetEnemyInfoList()
    {
        string sql = "select * from enemy_information";
        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if(dt.Rows.Count>0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                EnemyInfo enemyInfo = new EnemyInfo();
                enemyInfo.EnemyID = int.Parse(dr["enemy_id"].ToString());
                enemyInfo.EnemyName = dr["enemy_name"].ToString();
                enemyInfo.EnemyType = (EnemyTypes)int.Parse(dr["enemy_type"].ToString());
                enemyInfo.Hp= int.Parse(dr["enemy_hp"].ToString());
                enemyInfo.Exp = int.Parse(dr["enemy_exp"].ToString());
                enemyInfo.Damage = int.Parse(dr["enemy_damage"].ToString());
                enemyInfo.LeaveDistance = int.Parse(dr["enemy_leave_distance"].ToString());
                enemyInfo.MissPrecent = float.Parse(dr["enemy_miss_precent"].ToString());
                enemyInfo.MoveSpeed = int.Parse(dr["enemy_move_speed"].ToString());
                enemyInfo.AttackSpeed = int.Parse(dr["enemy_attack_speed"].ToString());
                enemyInfo.MinAttackDistance = int.Parse(dr["enemy_min_attack_distance"].ToString());
                enemyInfo.AttackAnimTime = float.Parse(dr["enemy_attack_animation_time"].ToString());
                enemyInfoList.Add(enemyInfo);
            }
        }
    }
    private void GetEnemyBirthInfoList()
    {
        string sql = "select * from enemy_birth_information";
        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                EnemyBirthInfo enemyBirthInfo = new EnemyBirthInfo();
                enemyBirthInfo.EnemyID = int.Parse(dr["enemy_id"].ToString());
                enemyBirthInfo.EnemyCount = int.Parse(dr["enemy_count"].ToString());
                enemyBirthInfo.EnemyType = (EnemyTypes)int.Parse(dr["enemy_type"].ToString());
                string SpawnPos = dr["enemy_spawn_poziton"].ToString();
                string[] pos = SpawnPos.Split(',');
                Vector3 vector3 = new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2]));
                enemyBirthInfo.EnemySpawnPos = vector3;
                enemyBirthInfo.EnemyPrefabsPath = dr["enemy_prefab_path"].ToString();
                enemyBirthInfoList.Add(enemyBirthInfo);
            }
        }
    }
    private void CreateEnemy()
    {
        for (int i = 0; i < enemyBirthInfoList.Count; i++)
        {

            for (int j = 0; j < enemyBirthInfoList[i].EnemyCount; j++)
            {
                GameObject pre = Resources.Load<GameObject>(enemyBirthInfoList[i].EnemyPrefabsPath);
                GameObject go = GameObject.Instantiate(pre, enemyBirthInfoList[i].EnemySpawnPos, Quaternion.identity);
                go.GetComponent<Enemy>().SetEnemyInfo(enemyInfoList[enemyBirthInfoList[i].EnemyID]);
                enemyGameObject.Add(go);
            }
        }
    }
    public void CreateOneEnemy(EnemyTypes enemyType)
    {
        EnemyBirthInfo enemyInfo = GetBirthInfoByEnemyTypes(enemyType);
        GameObject pre = Resources.Load<GameObject>(enemyInfo.EnemyPrefabsPath);
        GameObject go = GameObject.Instantiate(pre, enemyInfo.EnemySpawnPos, Quaternion.identity);
        go.GetComponent<Enemy>().SetEnemyInfo(enemyInfoList[enemyInfo.EnemyID]);
        enemyGameObject.Add(go);
    }
    public EnemyBirthInfo GetBirthInfoByEnemyTypes(EnemyTypes enemyType)
    {
        foreach (var item in enemyBirthInfoList)
        {
            if (item.EnemyType == enemyType)
                return item;
        }
        return null;
    }
}
