using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;
public class MouseCursorDAL
{
    public List<MouseCursorInfo> LoadMouseCursorInfoList()
    {
        List <MouseCursorInfo> list= new List<MouseCursorInfo>();

        string sql = "select * from mouse_cursor_information";

        DataTable dt= MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if(dt.Rows.Count>0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                MouseCursorInfo mci = new MouseCursorInfo();
                mci.Name = dr["mc_name"].ToString();
                mci.MouseCursorType = (MouseCursorTypes)Convert.ToInt32(dr["mc_type"]);
                mci.TexTurePath= dr["mc_sprite"].ToString();
                list.Add(mci);
            }
        }
        return list;
    }
}
