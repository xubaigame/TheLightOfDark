using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BaseTask
{

    #region 数据成员
    private string taskName;
    private string taskDes;
    private TaskState TaskStates;
    private string finishCon;
    private string taskPlan;
    private string taskAward;
    public TaskState State
    {
        get
        {
            return TaskStates;
        }

        set
        {

            TaskStates = value;
        }
    }
    public string TaskName
    {
        get
        {
            return taskName;
        }

        set
        {
            taskName = value;
        }
    }
    public string TaskDes
    {
        get
        {
            return taskDes;
        }

        set
        {
            taskDes = value;
        }
    }
    public string FinishCon
    {
        get
        {
            return finishCon;
        }

        set
        {
            finishCon = value;
        }
    }
    public string TaskPlan
    {
        get
        {
            return taskPlan;
        }

        set
        {
            taskPlan = value;
        }
    }
    public string TaskAward
    {
        get
        {
            return taskAward;
        }

        set
        {
            taskAward = value;
        }
    }
    public EnemyTypes EffectEnemyType;
    #endregion
    public  void Copy(BaseTask oldTask)
    {
        TaskName = oldTask.TaskName;
        TaskDes = oldTask.TaskDes;
        State = oldTask.State;
        FinishCon = oldTask.FinishCon;
        TaskPlan = oldTask.TaskPlan;
        TaskAward = oldTask.TaskAward;
    }

    public virtual void Init()
    {

    }
    protected virtual string TaskAcceptInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("任务描述:\n" + TaskDes + "\n\n");
        sb.Append("完成条件:\n" + FinishCon + "\n\n");
        sb.Append("任务奖励:\n");
        string[] Awards = TaskAward.Split('|');
        foreach (var Award in Awards)
        {
            string[] item = Award.Split(':');
            sb.Append(item[0] + " " + item[1] + "\n");
        }
        return sb.ToString();
    }
    protected virtual string TaskGoingInfo()
    {
        return String.Empty;
    }
    public virtual string ShowTaskInfo()
    {
        if (State == TaskState.NoStart)
            return "任务尚未开始";
        else if (State == TaskState.Accept)
            return TaskAcceptInfo();
        else if (State == TaskState.Going)
            return TaskGoingInfo();
        else
            return "任务已结束";
    }
    
    public virtual void StartTask()
    {

    }
    public virtual void AcceptTask()
    {

    }
    public virtual void GoingTask()
    {

    }
    public virtual void FinishTask()
    {
        
    }

    public virtual void CancelTask()
    {

    }
    public virtual bool IsFinishTask()
    {
        return false;
    }
    public virtual void SetTaskPlant()
    {

    }
}
