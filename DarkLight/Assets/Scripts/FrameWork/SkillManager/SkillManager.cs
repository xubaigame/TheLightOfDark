using FairyGUI;
using LitJson;
using System;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;

public class SkillManager : SingLeton<SkillManager>
{
	#region 数据成员
	//技能列表
	private List<SkillListItem> SkillItemList;
	#endregion

	#region 事件
	//UI更新事件
	public Action UpdateUI;
	#endregion

	/// <summary>
	/// 初始化函数,加载文件路径
	/// </summary>
	public void Init()
	{
        PlayerStatusManager.Instance.LvUP += StartUpdateUI;
        List<BaseSkill> SkillInfoList = new List<BaseSkill>();
		SkillItemList = new List<SkillListItem>();
        string sql = "select * from skill_information";

        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
		foreach (DataRow item in dt.Rows)
		{
			Type type = Type.GetType(item["skill_type"].ToString());
			object[] parameters = new object[1];
			parameters[0] = item;
			object obj = Activator.CreateInstance(type, parameters);
			BaseSkill bs = obj as BaseSkill;
			SkillInfoList.Add(bs);
		}
		for (int i = 0; i < SkillInfoList.Count; i++)
		{
			if (SkillInfoList[i].PlayerType == PlayerStatusManager.Instance.playerInfo.PlayerType)
			{
				SkillListItem si = (SkillListItem)UIPackage.CreateObject("SkillMenu", "SkillListItem");
				si.SkillInfo = SkillInfoList[i];
				si.SetValues();
				SkillItemList.Add(si);
			}
		}
	}
	/// <summary>
	/// 显示技能列表信息
	/// </summary>
	/// <param name="shopList"></param>
	public void SetSkillItemToList(GList skillList)
	{
		for (int i = 0; i < SkillItemList.Count; i++)
		{
			if (SkillItemList[i].SkillInfo.PlayerLevel > PlayerStatusManager.Instance.playerInfo.Lv)
			{
				SkillItemList[i].GetChild("icon").enabled = false;
				SkillItemList[i].onDragStart.Remove(OnDragStart);
				SkillItemList[i].draggable = false;
			}
			else
			{
				SkillItemList[i].GetChild("icon").enabled = true;
				SkillItemList[i].onDragStart.Add(OnDragStart);
				SkillItemList[i].draggable = true;
			}
            skillList.AddChild(SkillItemList[i]);
		}
	}

	/// <summary>
	/// 根据技能ID获取技能信息
	/// </summary>
	/// <param name="skillID">技能ID</param>
	/// <returns></returns>
	public BaseSkill GetsKillByID(int skillID)
	{
		foreach (var item in SkillItemList)
		{
			if (item.SkillInfo.SkillID == skillID)
				return item.SkillInfo;
		}
		return null;
	}
	private void OnDragStart(EventContext context)
	{
		SkillListItem si = (SkillListItem)context.sender;
		context.PreventDefault();
		//DragDropManager.inst.StartDrag(sb, sb.icon, sb.icon, (int)context.data);
		DragDropManager.inst.StartDrag(si, si.Icon.icon, si, (int)context.data);
	}
	private void StartUpdateUI()
	{
		if (UpdateUI != null)
			UpdateUI();
	}
}
