using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using MySql.Data.MySqlClient;
using System;

public class BagManagerDAL
{

    public void CreateNewPlayer()
    {
        string sql = "select * from bag_item_information where user_id=" + GameConfig.UserId;
        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if (dt.Rows.Count > 0)
        {
            sql = "update bag_item_information set item_id=@item_id,slot_item_count=@slot_item_count where user_id=" + GameConfig.UserId + " and slot_id=";
            MySqlParameter[] ps =
            {
                new MySqlParameter("@item_id", DBNull.Value),
                new MySqlParameter("@slot_item_count",0)
            };
            string sql_next;
            for (int i = 0; i < 25; i++)
            {
                ps[1].Value = 0;
                sql_next = sql + i;
                MysqlHelper.ExecutNonQuery(sql_next, CommandType.Text, ps);
            }
        }

        else
        {
            sql = "insert into bag_item_information values(@user_id,@slot_id,@item_id,@slot_item_count)";
            MySqlParameter[] ps =
            {
                new MySqlParameter("@user_id",GameConfig.UserId),
                new MySqlParameter("@slot_id",0),
                new MySqlParameter("@item_id",DBNull.Value),
                new MySqlParameter("@slot_item_count",0)
            };
            for (int i = 0; i < 25; i++)
            {
                ps[1].Value = i;
                ps[3].Value = 0;
                MysqlHelper.ExecutNonQuery(sql, CommandType.Text, ps);
            }
        }
    }
    public List<SlotInfo> LoadBagInfo()
    {
        List<SlotInfo> slotInfos = new List<SlotInfo>();
        string sql = "select * from bag_item_information where user_id=" + GameConfig.UserId;
        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                SlotInfo slotInfo = new SlotInfo();
                slotInfo.SlotID = int.Parse(dr["slot_id"].ToString());
                slotInfo.ItemCount = int.Parse(dr["slot_item_count"].ToString());
                if(dr["item_id"]==DBNull.Value)
                {
                    slotInfo.ItemID = -1;
                }
                else
                {
                    slotInfo.ItemID = int.Parse(dr["item_id"].ToString());
                }
                slotInfos.Add(slotInfo);
            }
        }
        slotInfos.Sort(delegate (SlotInfo x, SlotInfo y)
        {
            return x.SlotID.CompareTo(y.SlotID);
        });
        return slotInfos;
    }
    public void SaveLoadBagInfo(List<SlotInfo> slotInfos)
    {
        string sql = "update bag_item_information set item_id=@item_id,slot_item_count=@slot_item_count where user_id="+GameConfig.UserId+" and slot_id=";
        string sql_next;
        MySqlParameter[] ps =
        {
                new MySqlParameter("@item_id", 0),
                new MySqlParameter("@slot_item_count",0)
        };
        for (int i = 0; i < 25; i++)
        {
            if(slotInfos[i].ItemID==-1)
            {
                ps[0].Value = DBNull.Value;
            }
            else
            {
                ps[0].Value = slotInfos[i].ItemID;
            }
            ps[1].Value = slotInfos[i].ItemCount;
            sql_next = sql + i;
            MysqlHelper.ExecutNonQuery(sql_next, CommandType.Text, ps);
        }
    }
}