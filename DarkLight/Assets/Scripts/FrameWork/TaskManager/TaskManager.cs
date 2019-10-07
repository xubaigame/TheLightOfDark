using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;
using System.Text;
using System.IO;

public class TaskManager : SingLeton<TaskManager> {

    #region 数据成员
    private TaskInfoDAL taskInfoDAL = new TaskInfoDAL();
    //当前正在进行的任务类
    public BaseTask currentTask;
    #endregion

    #region 委托事件
    private Action TaskStart;//任务开始时
    private Action TaskAccept;//接受任务时
    private Action TaskGoing;//任务执行过程中
    private Action TaskFinish;//任务完成时
    private Action TaskCancel;//任务被取消时
    public Action UpdateUI;
    #endregion

    /// <summary>
    /// 初始化任务管理器
    /// </summary>
    public void Init()
    { 
        LoadTask();
    }

    /// <summary>
    /// 加载人物文件中的信息
    /// </summary>
    private void LoadTask()
    {
        currentTask = taskInfoDAL.GetInitTask();
        CheckCurrentState();
    }

    /// <summary>
    /// 保存当前任务状态
    /// </summary>
    public void SaveTask()
    {
        taskInfoDAL.SaveTaskInfo(currentTask);
    }

    /// <summary>
    /// 获取任务当前状态
    /// </summary>
    public bool GetTaskState()
    {
        if (currentTask.State == TaskState.Accept)
            return true;
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 开始任务时的处理函数
    /// </summary>
    private void StartTask()
    {
        AddLinster();
        TaskStart();
    }

    /// <summary>
    /// 接受任务时的处理函数
    /// </summary>
    public void AcceptTask()
    {
        currentTask.State = TaskState.Going;
        if(TaskAccept!=null)
        {
            TaskAccept();
        }
        StartEvent();
    }

    /// <summary>
    /// 执行任务时的处理函数
    /// </summary>
    public void GoingTask()
    {
        if(TaskGoing!=null)
        {
            TaskGoing();
        }
        StartEvent();
    }

    /// <summary>
    /// 完成任务时的处理函数
    /// </summary>
    public bool FinishTask()
    {
        if(currentTask.IsFinishTask())
        {
            if (TaskFinish!=null)
            {
                TaskFinish();
            }
            currentTask.State = TaskState.Finish;
            RemoveLinster();
            TrunNextTask();
            return true;

        }
        else
        {
            return false;
        }
        
    }

    /// <summary>
    /// 取消任务时的处理函数
    /// </summary>
    public void CancelTask()
    {
        currentTask.State = TaskState.Accept;
        if(TaskCancel!=null)
        {
            TaskCancel();
        }
        RemoveLinster();
        StartEvent();
    }

    /// <summary>
    /// 委托的注册处理函数
    /// </summary> 
    private void AddLinster()
    {
        TaskStart += currentTask.StartTask;
        TaskAccept += currentTask.AcceptTask;
        TaskGoing += currentTask.GoingTask;
        TaskFinish += currentTask.FinishTask;
        TaskCancel += currentTask.CancelTask;
    }

    /// <summary>
    /// 委托的取消注册处理函数
    /// </summary>
    private void RemoveLinster()
    {
        if (TaskStart != null)
        {
            TaskStart -= currentTask.StartTask;
        }
        if(TaskAccept!=null)
        {
            TaskAccept -= currentTask.AcceptTask;
        }
        if (TaskGoing != null)
        {
            TaskGoing -= currentTask.GoingTask;
        }
        if (TaskFinish != null)
        {
            TaskFinish -= currentTask.FinishTask;
        }
        if(TaskCancel !=null)
        {
            TaskCancel -= currentTask.CancelTask;
        }
    }

    private void StartEvent()
    {
        if (UpdateUI != null)
            UpdateUI();
    }
    private void TrunNextTask()
    {
        currentTask = taskInfoDAL.GetNextTaskInfo();
        CheckCurrentState();
    }
    private void CheckCurrentState()
    {
        if (currentTask == null)
        {
            currentTask = new BaseTask();
            currentTask.State = TaskState.Finish;
        }
        else if (currentTask.State == TaskState.NoStart)
        {
            currentTask.Init();
            StartTask();
        }
        StartEvent();
    }
}
