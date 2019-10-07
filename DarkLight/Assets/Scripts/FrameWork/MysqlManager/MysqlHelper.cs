using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;

public static class MysqlHelper
{
    public static readonly string conStr = GameConfig.conStr;

    /// <summary>
    /// 对数据库的增加,删除,修改
    /// </summary>  
    /// <param name="sql">SQL语句</param>
    /// <param name="type">连接类型</param>
    /// <param name="ps">参数列表</param>
    /// <returns></returns>
    public static int ExecutNonQuery(string sql, CommandType type, params MySqlParameter[] ps)
    {
        try
        {
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    cmd.CommandType = type;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception)
        {
            return 0;
        }
        
    }

    /// <summary>
    /// 查询首行首列
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <param name="type">连接类型</param>
    /// <param name="ps">参数列表</param>
    /// <returns></returns>
    public static object ExecuteScalar(string sql, CommandType type, params MySqlParameter[] ps)
    {
        using (MySqlConnection con = new MySqlConnection(conStr))
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                cmd.CommandType = type;
                con.Open();
                return cmd.ExecuteScalar();
            }
        }
    }

    /// <summary>
    /// 返回查询器
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <param name="type">连接类型</param>
    /// <param name="ps">参数列表</param>
    /// <returns></returns>
    public static MySqlDataReader ExecuteReader(string sql, CommandType type, params MySqlParameter[] ps)
    {
        MySqlConnection con = new MySqlConnection(conStr);
        using (MySqlCommand cmd = new MySqlCommand(sql, con))
        {
            if (ps != null)
            {
                cmd.Parameters.AddRange(ps);
            }
            try
            {
                cmd.CommandType = type;
                con.Open();
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                con.Close();
                con.Dispose();
                throw ex;
            }
        }
    }

    /// <summary>
    /// 查询返回满足条件的集合(表)
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <param name="type">连接类型</param>
    /// <param name="ps">参数列表</param>
    /// <returns></returns>
    public static DataTable ExecuteTable(string sql, CommandType type, params MySqlParameter[] ps)
    {
        
        try
        {
            DataTable dt = new DataTable();
            using (MySqlDataAdapter sda = new MySqlDataAdapter(sql, conStr))
            {
                if (ps != null)
                {
                    sda.SelectCommand.Parameters.AddRange(ps);
                }
                sda.Fill(dt);
            }
            return dt;
        }
        catch (Exception)
        {
            return null;
        }
       
    }
}