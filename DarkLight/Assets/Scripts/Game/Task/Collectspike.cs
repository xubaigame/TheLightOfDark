using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class Collectspike : BaseTask
{
	private int killNum;
    private int FinishNum;
    private int Coin;

	public override void Init()
	{
		string[] Task = TaskPlan.Split('/');
		killNum = Convert.ToInt32(Task[0]);
		FinishNum = Convert.ToInt32(Task[1]);
		if (State == TaskState.NoStart)
		State = TaskState.Accept;
		string[] Awards = TaskAward.Split('|');
		string[] Award = Awards[0].Split(':');
		Coin = Convert.ToInt32(Award[1]);

	}
	protected override string TaskAcceptInfo()
	{
		return base.TaskAcceptInfo();
	}

	protected override string TaskGoingInfo()
	{
		StringBuilder sb = new StringBuilder();
		sb.Append("任务进度:\n" );
		sb.Append("收集的牙齿数:" + "\n" + killNum+"/"+FinishNum);
		sb.Append("\n");
        return sb.ToString();
	}
	public override bool IsFinishTask()
	{
		if (killNum >= FinishNum)
			return true;
		else return false;

	}
    public override void StartTask()
    {
        killNum = 0;
        SetTaskPlant();
    }
    public override void FinishTask()
	{
		PlayerStatusManager.Instance.AddMoney(Coin);
		killNum = 0;
		SetTaskPlant();
	}
	public override void GoingTask()
	{
        killNum++;
        SetTaskPlant();
	}
	public override void CancelTask()
	{
		killNum = 0;
		SetTaskPlant();
	}
    public override void AcceptTask()
    {
        killNum = 0;
        SetTaskPlant();
    }
    public override void SetTaskPlant()
	{
		TaskPlan = killNum + "/" + FinishNum;
	}
}
