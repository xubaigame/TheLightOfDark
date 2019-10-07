using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;

public class EquipmentManagerDAL
{
    public void CreateNewPlayer()
    {
        string sql = "select * from equipment_item_information where user_id="+GameConfig.UserId;
        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if(dt.Rows.Count>0)
        {
            sql = "update equipment_item_information set item_id=@item_id,equipment_type=@equipment_type where user_id="+GameConfig.UserId+ " and equipment_slot_id=";
            MySqlParameter[] ps =
            {
                new MySqlParameter("@item_id", DBNull.Value),
                new MySqlParameter("@equipment_type",0)
            };
            string sql_next;
            for (int i = 0; i < 6; i++)
            {
                ps[1].Value = i;
                sql_next = sql + i;
                MysqlHelper.ExecutNonQuery(sql_next, CommandType.Text, ps);
            }
        }
        else
        {
            sql = "insert into equipment_item_information values(@user_id,@equipment_slot_id,@item_id,@equipment_type)";
            MySqlParameter[] ps =
            {
                new MySqlParameter("@user_id", GameConfig.UserId),
                new MySqlParameter("@equipment_slot_id", 0),
                new MySqlParameter("@item_id", DBNull.Value),
                new MySqlParameter("@equipment_type", 0)
            };
            for (int i = 0; i < 6; i++)
            {
                ps[1].Value = i;
                ps[3].Value = i;
                MysqlHelper.ExecutNonQuery(sql, CommandType.Text, ps);
            }
        }
    }
    public List<EquipmentInfo> LoadEquipmentInfo()
    {
        List<EquipmentInfo> equipmentInfos = new List<EquipmentInfo>();
        string sql = "select * from equipment_item_information where user_id="+GameConfig.UserId;
        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if(dt.Rows.Count>0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                EquipmentInfo equipmentInfo = new EquipmentInfo();
                equipmentInfo.EquipmentType = (EquipmentTypes)int.Parse(dr["equipment_type"].ToString());
                if(dr["item_id"] ==DBNull.Value)
                {
                    equipmentInfo.ItemID = -1;
                }
                else
                {
                    equipmentInfo.ItemID = int.Parse(dr["item_id"].ToString());
                }
                equipmentInfos.Add(equipmentInfo);
            }
        }
        return equipmentInfos;
    }
    public void SaveEquipmentInfo(List<EquipmentInfo> equipmentInfos)
    {
        string sql = "update equipment_item_information set item_id=@item_id,equipment_type=@equipment_type where user_id=" + GameConfig.UserId + " and equipment_slot_id=";
        string sql_next;
        MySqlParameter[] ps =
        {
                new MySqlParameter("@item_id", 0),
                new MySqlParameter("@equipment_type",0)
        };
        for (int i = 0; i < 6; i++)
        {
            if (equipmentInfos[i].ItemID == -1)
            {
                ps[0].Value = DBNull.Value;
            }
            else
            {
                ps[0].Value = equipmentInfos[i].ItemID;
            }
            ps[1].Value = i;
            sql_next = sql + i;
            MysqlHelper.ExecutNonQuery(sql_next, CommandType.Text, ps);
        }
    }
}
