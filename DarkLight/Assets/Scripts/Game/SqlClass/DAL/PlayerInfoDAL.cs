using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

public class PlayerInfoDAL
{
    public DataTable Player_status_information()
    {
        string sql = "select * from player_status_information where player_type=" + "'"+GameConfig.playerTypes.ToString() + "'";
        return MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
    }
    public void DeleteOldPlayer()
    {
        string sql = "delete from user_player_status_information where user_id=" + GameConfig.UserId;
        MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
    }
    public int CreateNewPlayer()
    {
        PlayerStatusInfo playerStatusInfo = new PlayerStatusInfo();
        DataTable dt = Player_status_information();
        if(dt.Rows.Count>=0)
        {
            playerStatusInfo.Name = GameConfig.PlayerName;
            playerStatusInfo.Hp = Convert.ToInt32(dt.Rows[0]["player_hp"]);
            playerStatusInfo.Hp_Remain = playerStatusInfo.Hp;
            playerStatusInfo.Mp= Convert.ToInt32(dt.Rows[0]["player_mp"]);
            playerStatusInfo.Mp_Remain = playerStatusInfo.Mp;
            playerStatusInfo.Exp = Convert.ToInt32(dt.Rows[0]["player_exp"]);
            playerStatusInfo.ReMain_EXP = 0;
            playerStatusInfo.Lv = 1;
            playerStatusInfo.Attack= Convert.ToInt32(dt.Rows[0]["player_attack"]);
            playerStatusInfo.Attack_Add = 0;
            playerStatusInfo.Def = Convert.ToInt32(dt.Rows[0]["player_defence"]);
            playerStatusInfo.Def_Add = 0;
            playerStatusInfo.Speed = Convert.ToInt32(dt.Rows[0]["player_speed"]);
            playerStatusInfo.Speed_Add = 0;
            playerStatusInfo.AttackSpeed = Convert.ToInt32(dt.Rows[0]["player_attack_speed"]);
            playerStatusInfo.AttackDistance = Convert.ToInt32(dt.Rows[0]["player_attack_distance"]);
            playerStatusInfo.MissPrecent = Convert.ToInt32(dt.Rows[0]["player_miss_precent"]);
            playerStatusInfo.PlayerType = GameConfig.playerTypes;
        }

        string sql = "insert into user_player_status_information(user_id,user_player_id,user_player_name,user_player_hp,user_player_remain_hp," +
            "user_player_mp,user_player_remain_mp,user_player_exp,user_player_now_exp,user_player_level,user_player_coin,user_player_attack,user_player_add_attack," +
            "user_player_defence,user_player_add_defence,user_player_speed,user_player_add_speed,user_player_attack_speed,user_player_attack_distance," +
            "user_player_miss_precent,user_player_type) values(@user_id,@user_player_id,@user_player_name,@user_player_hp,@user_player_remain_hp," +
            "@user_player_mp,@user_player_remain_mp,@user_player_exp,@user_player_now_exp,@user_player_level,@user_player_coin,@user_player_attack,@user_player_add_attack," +
            "@user_player_defence,@user_player_add_defence,@user_player_speed,@user_player_add_speed,@user_player_attack_speed,@user_player_attack_distance," +
            "@user_player_miss_precent,@user_player_type)";
        MySqlParameter[] ps =
        {
            new MySqlParameter("@user_id",GameConfig.UserId),
            new MySqlParameter("@user_player_id",(int)GameConfig.playerTypes),
            new MySqlParameter("@user_player_name",playerStatusInfo.Name),
            new MySqlParameter("@user_player_hp",playerStatusInfo.Hp),
            new MySqlParameter("@user_player_remain_hp",playerStatusInfo.Hp_Remain),
            new MySqlParameter("@user_player_mp",playerStatusInfo.Mp),
            new MySqlParameter("@user_player_remain_mp",playerStatusInfo.Mp_Remain),
            new MySqlParameter("@user_player_exp",playerStatusInfo.Exp),
            new MySqlParameter("@user_player_now_exp",playerStatusInfo.ReMain_EXP),
            new MySqlParameter("@user_player_level",playerStatusInfo.Lv),
            new MySqlParameter("@user_player_coin",1000),
            new MySqlParameter("@user_player_attack",playerStatusInfo.Attack),
            new MySqlParameter("@user_player_add_attack",playerStatusInfo.Attack_Add),  
            new MySqlParameter("@user_player_defence",playerStatusInfo.Def),
            new MySqlParameter("@user_player_add_defence",playerStatusInfo.Def_Add),
            new MySqlParameter("@user_player_speed",playerStatusInfo.Speed),
            new MySqlParameter("@user_player_add_speed",playerStatusInfo.Speed_Add),
            new MySqlParameter("@user_player_attack_speed",playerStatusInfo.AttackSpeed),
            new MySqlParameter("@user_player_attack_distance",playerStatusInfo.AttackDistance),
            new MySqlParameter("@user_player_miss_precent",playerStatusInfo.MissPrecent),
            new MySqlParameter("@user_player_type",playerStatusInfo.PlayerType.ToString()),
        };

        return MysqlHelper.ExecutNonQuery(sql, CommandType.Text, ps);
    }

    public PlayerStatusInfo LoadPlayerStatusInfo()
    {
        string sql = "select * from user_player_status_information where user_id=" + GameConfig.UserId;
        DataTable dt=MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        
        if (dt.Rows.Count>0)
        {
            GameConfig.playerTypes = (PlayerTypes)Enum.Parse(typeof(PlayerTypes), dt.Rows[0]["user_player_type"].ToString());
            GameConfig.PlayerName= dt.Rows[0]["user_player_name"].ToString();
            PlayerStatusInfo playerStatusInfo = new PlayerStatusInfo();
            playerStatusInfo.Name = GameConfig.PlayerName;
            playerStatusInfo.Hp = Convert.ToInt32(dt.Rows[0]["user_player_hp"]);
            playerStatusInfo.Hp_Remain = Convert.ToInt32(dt.Rows[0]["user_player_remain_hp"]);
            playerStatusInfo.Mp= Convert.ToInt32(dt.Rows[0]["user_player_mp"]);
            playerStatusInfo.Mp_Remain = Convert.ToInt32(dt.Rows[0]["user_player_remain_mp"]);
            playerStatusInfo.Exp = Convert.ToInt32(dt.Rows[0]["user_player_exp"]);
            playerStatusInfo.ReMain_EXP = Convert.ToInt32(dt.Rows[0]["user_player_now_exp"]);
            playerStatusInfo.Lv = Convert.ToInt32(dt.Rows[0]["user_player_level"]);
            playerStatusInfo.Money = Convert.ToInt32(dt.Rows[0]["user_player_coin"]);
            playerStatusInfo.Attack= Convert.ToInt32(dt.Rows[0]["user_player_attack"]);
            playerStatusInfo.Attack_Add = Convert.ToInt32(dt.Rows[0]["user_player_add_attack"]);
            playerStatusInfo.Def = Convert.ToInt32(dt.Rows[0]["user_player_defence"]);
            playerStatusInfo.Def_Add = Convert.ToInt32(dt.Rows[0]["user_player_add_defence"]);
            playerStatusInfo.Speed = Convert.ToInt32(dt.Rows[0]["user_player_speed"]);
            playerStatusInfo.Speed_Add = Convert.ToInt32(dt.Rows[0]["user_player_add_speed"]);
            playerStatusInfo.AttackSpeed = Convert.ToInt32(dt.Rows[0]["user_player_attack_speed"]);
            playerStatusInfo.AttackDistance = Convert.ToInt32(dt.Rows[0]["user_player_attack_distance"]);
            playerStatusInfo.MissPrecent = Convert.ToInt32(dt.Rows[0]["user_player_miss_precent"]);
            playerStatusInfo.PlayerType = GameConfig.playerTypes;
            return playerStatusInfo;
        }
        return null;
    }
    public void SavePlayerStatusInfo(PlayerStatusInfo playerStatusInfo)
    {
        string sql = "update user_player_status_information set " +
            "user_player_remain_hp=@user_player_remain_hp," +
            "user_player_remain_mp=@user_player_remain_mp," +
            "user_player_now_exp=@user_player_now_exp," +
            "user_player_level=@user_player_level," +
            "user_player_coin=@user_player_coin," +
            "user_player_add_attack=@user_player_add_attack," +
            "user_player_add_defence=@user_player_add_defence," +
            "user_player_add_speed=@user_player_add_speed where user_id=" + GameConfig.UserId;

        MySqlParameter[] ps =
        {
            new MySqlParameter("@user_player_remain_hp",playerStatusInfo.Hp_Remain==0?1:playerStatusInfo.Hp_Remain),
            new MySqlParameter("@user_player_remain_mp",playerStatusInfo.Mp_Remain),
            new MySqlParameter("@user_player_now_exp",playerStatusInfo.ReMain_EXP),
            new MySqlParameter("@user_player_level",playerStatusInfo.Lv),
            new MySqlParameter("@user_player_coin",playerStatusInfo.Money),
            new MySqlParameter("@user_player_add_attack",playerStatusInfo.Attack_Add),
            new MySqlParameter("@user_player_add_defence",playerStatusInfo.Def_Add),
            new MySqlParameter("@user_player_add_speed",playerStatusInfo.Speed_Add)
        };

        MysqlHelper.ExecutNonQuery(sql, CommandType.Text, ps);
    }
    public void LVUpdate(PlayerStatusInfo playerStatusInfo)
    {
        PlayerStatusInfo temp = new PlayerStatusInfo();
        DataTable dt = Load_play_development_information();
        if (dt.Rows.Count >= 0)
        {
            temp.Hp = Convert.ToInt32(dt.Rows[0]["player_add_hp"]);
            temp.Mp = Convert.ToInt32(dt.Rows[0]["player_add_mp"]);
            temp.Exp = Convert.ToInt32(dt.Rows[0]["player_add_exp"]);
            temp.Attack = Convert.ToInt32(dt.Rows[0]["player_add_attack"]);
            temp.Def = Convert.ToInt32(dt.Rows[0]["player_add_defence"]);
            temp.Speed = Convert.ToInt32(dt.Rows[0]["player_add_speed"]);
        }

        string sql = "update user_player_status_information set " +
            "user_player_mp=@user_player_mp," +
            "user_player_hp=@user_player_hp," +
            "user_player_exp=@user_player_exp," +
            "user_player_level=@user_player_level," +
            "user_player_attack=@user_player_attack," +
            "user_player_defence=@user_player_defence," +
            "user_player_speed=@user_player_speed where user_id=" + GameConfig.UserId;
        playerStatusInfo.Mp += temp.Mp;
        playerStatusInfo.Hp += temp.Hp;
        playerStatusInfo.Exp += temp.Exp;
        playerStatusInfo.Attack += temp.Attack;
        playerStatusInfo.Def += temp.Def;
        playerStatusInfo.Speed += temp.Speed;
        MySqlParameter[] ps =
        {
            new MySqlParameter("@user_player_mp",playerStatusInfo.Mp),
            new MySqlParameter("@user_player_hp",playerStatusInfo.Hp),
            new MySqlParameter("@user_player_exp",playerStatusInfo.Exp),
            new MySqlParameter("@user_player_level",playerStatusInfo.Lv),
            new MySqlParameter("@user_player_attack",playerStatusInfo.Attack),
            new MySqlParameter("@user_player_defence",playerStatusInfo.Def),
            new MySqlParameter("@user_player_speed",playerStatusInfo.Speed)
        };
        MysqlHelper.ExecutNonQuery(sql, CommandType.Text, ps);
    }
    public DataTable Load_play_development_information()
    {
        string sql = "select * from play_development_information where player_id="+((int)GameConfig.playerTypes);
        return MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
    }
}
