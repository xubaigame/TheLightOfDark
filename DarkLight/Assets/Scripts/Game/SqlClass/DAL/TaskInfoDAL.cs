using MySql.Data.MySqlClient;
using System;
using System.Data;

public class TaskInfoDAL
{
    public void CreateOneTask()
    {
        string sql = "delete from user_task_information where user_id=" + GameConfig.UserId;
        MysqlHelper.ExecutNonQuery(sql, CommandType.Text, null);
        sql = "select * from task_information where task_id=0";
        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if(dt.Rows.Count>0)
        {
            sql = "insert into user_task_information values(@user_id,@task_id,@task_state,@task_plan)";
            MySqlParameter[] ps =
            {
            new MySqlParameter("@user_id",GameConfig.UserId),
            new MySqlParameter("@task_id",int.Parse(dt.Rows[0]["task_id"].ToString())),
            new MySqlParameter("@task_state",TaskState.NoStart),
            new MySqlParameter("@task_plan",dt.Rows[0]["task_plan"].ToString())
            };
            MysqlHelper.ExecutNonQuery(sql, CommandType.Text, ps);
        }
    }
    public BaseTask GetInitTask()
    {
        Collectspike bt = new Collectspike();
        string sql = "select * from user_task_information where user_id=" + GameConfig.UserId;
        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if (dt.Rows.Count > 0)
        {
            GameConfig.TaskID = int.Parse(dt.Rows[0]["task_id"].ToString());
            bt.TaskPlan = dt.Rows[0]["task_plan"].ToString();
            bt.State = (TaskState)int.Parse(dt.Rows[0]["task_state"].ToString());
            sql = "select * from task_information where task_id=" + GameConfig.TaskID;
            DataTable dt1= MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
            if(dt1.Rows.Count>0)
            {
                bt.TaskName = dt1.Rows[0]["task_name"].ToString();
                bt.TaskDes = dt1.Rows[0]["task_description"].ToString();
                bt.FinishCon = dt1.Rows[0]["task_finish_condition"].ToString();
                bt.TaskAward = dt1.Rows[0]["task_award"].ToString();
                bt.EffectEnemyType = (EnemyTypes)Enum.Parse(typeof(EnemyTypes), dt1.Rows[0]["task_EffectEnemyType"].ToString());
                if(dt1.Rows[0]["task_next_task"]==DBNull.Value)
                {
                    GameConfig.NextTaskID = -1;
                }
                else
                {
                    GameConfig.NextTaskID = int.Parse(dt1.Rows[0]["task_next_task"].ToString());
                }
                return bt;
            }
        }
        return null;
    }
    public void SaveTaskInfo(BaseTask currentTask)
    {
        string sql = "update user_task_information set task_id=@task_id,task_state=@task_state,task_plan=@task_plan";
        MySqlParameter[] ps =
        {
            new MySqlParameter("@task_id",GameConfig.TaskID),
            new MySqlParameter("@task_state",currentTask.State),
            new MySqlParameter("@task_plan",currentTask.TaskPlan)
        };
        MysqlHelper.ExecutNonQuery(sql, CommandType.Text, ps);
    }
    public BaseTask GetNextTaskInfo()
    {
        if(GameConfig.NextTaskID==-1)
        {
            return null;
        }
        string sql = "delete from user_task_information where user_id=" + GameConfig.UserId;
        MysqlHelper.ExecutNonQuery(sql, CommandType.Text, null);
        sql = "select * from task_information where task_id="+ GameConfig.NextTaskID;
        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if (dt.Rows.Count > 0)
        {
            sql = "insert into user_task_information values(@user_id,@task_id,@task_state,@task_plan)";
            MySqlParameter[] ps =
            {
            new MySqlParameter("@user_id",GameConfig.UserId),
            new MySqlParameter("@task_id",int.Parse(dt.Rows[0]["task_id"].ToString())),
            new MySqlParameter("@task_state",TaskState.NoStart),
            new MySqlParameter("@task_plan",dt.Rows[0]["task_plan"].ToString())
            };
            MysqlHelper.ExecutNonQuery(sql, CommandType.Text, ps);
            return GetInitTask();
        }
        return null;
    }
}
