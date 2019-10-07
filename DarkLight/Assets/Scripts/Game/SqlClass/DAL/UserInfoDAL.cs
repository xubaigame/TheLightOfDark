using MySql.Data.MySqlClient;
using System;
using System.Data;

public class UserInfoDAL
{
    public int AddUserInfo(UserInfo userInfo)
    {
        string sql = "insert into user_information(user_name,user_password,user_last_login_time) values(@user_name,@user_password,now())";
        MySqlParameter[] ps ={
            new MySqlParameter("@user_name", userInfo.UserName),
            new MySqlParameter("@user_password", userInfo.UserPwd)
        };
        return MysqlHelper.ExecutNonQuery(sql, CommandType.Text, ps);
    }
    public bool Login(UserInfo userInfo,out string msg)
    {
        DataTable dt = GetUserInfo(userInfo.UserName);
        if (dt.Rows.Count > 0)
        {
            if(dt.Rows[0]["user_password"].ToString()== userInfo.UserPwd)
            {
                msg = "登录成功";
                return true;
            }
            else
            {
                msg = "密码错误";
                return false;
            }
        }
        else
        {
            msg = "用户不存在";
            return false;
        }
    }
    public int GetUserID(string userName)
    {
        DataTable dt = GetUserInfo(userName);
        if (dt.Rows.Count > 0)
        {
            return Convert.ToInt32(dt.Rows[0]["user_id"]);
            
        }
        else return -1;
    }
    public DataTable GetUserInfo(string userName)
    {
        string sql = "select * from user_information where user_name=@user_name";
        MySqlParameter ps = new MySqlParameter("@user_name", userName);
        return MysqlHelper.ExecuteTable(sql, CommandType.Text, ps);
    }
}
