using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

public class ShortCutManagerDAL
{
    public void CreateNewPlayer()
    {
        string sql = "select * from shortcut_information where user_id=" + GameConfig.UserId;
        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if (dt.Rows.Count > 0)
        {
            sql = "update shortcut_information set skill_id=@skill_id where user_id=" + GameConfig.UserId + " and shortcut_id=";
            MySqlParameter ps = new MySqlParameter("@skill_id", DBNull.Value);
            string sql_next;
            for (int i = 0; i < 6; i++)
            {
                sql_next = sql + i;
                MysqlHelper.ExecutNonQuery(sql_next, CommandType.Text, ps);
            }
        }
        else
        {
            sql = "insert into shortcut_information values(@user_id,@shortcut_id,@skill_id)";
            MySqlParameter[] ps =
            {
                new MySqlParameter("@user_id", GameConfig.UserId),
                new MySqlParameter("@shortcut_id", 0),
                new MySqlParameter("@skill_id", DBNull.Value),
            };
            for (int i = 0; i < 6; i++)
            {
                ps[1].Value = i;
                MysqlHelper.ExecutNonQuery(sql, CommandType.Text, ps);
            }
        }
    }
    public List<ShortCutInfo> LoadShortCutInfo()
    {
        List<ShortCutInfo> shortCutInfos = new List<ShortCutInfo>();
        string sql = "select * from shortcut_information where user_id=" + GameConfig.UserId+ " order by shortcut_id";
        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if(dt.Rows.Count>0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ShortCutInfo shortCutInfo = new ShortCutInfo();
                shortCutInfo.ShortCutID = int.Parse(dr["shortcut_id"].ToString());
                if(dr["skill_id"] ==DBNull.Value)
                {
                    shortCutInfo.SkillID = -1;
                }
                else
                {
                    shortCutInfo.SkillID = int.Parse(dr["skill_id"].ToString());
                }
                shortCutInfos.Add(shortCutInfo);
            }
        }
        return shortCutInfos;
    }
    public void SaveShortCutInfo(List<ShortCutInfo> shortCutInfos)
    {
        string sql = "update shortcut_information set skill_id=@skill_id where user_id=" + GameConfig.UserId + " and shortcut_id=";
        string sql_next;
        MySqlParameter ps = new MySqlParameter("@skill_id", 0);
        for (int i = 0; i < 6; i++)
        {
            if (shortCutInfos[i].SkillID == -1)
            {
                ps.Value = DBNull.Value;
            }
            else
            {
                ps.Value = shortCutInfos[i].SkillID;
            }
            sql_next = sql + i;
            MysqlHelper.ExecutNonQuery(sql_next, CommandType.Text, ps);
        }
    }
}
