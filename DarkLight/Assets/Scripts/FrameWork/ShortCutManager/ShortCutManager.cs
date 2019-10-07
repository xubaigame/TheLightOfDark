using FairyGUI;
using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShortCutManager : SingLeton<ShortCutManager>
{
    #region 数据成员
    private ShortCutManagerDAL shortCutManagerDAL = new ShortCutManagerDAL();
    List<ShortCutInfo> shortCutInfoList;
    //快捷栏信息列表
    private List<ShortCutButton> shortCutList;
    //
    private Dictionary<KeyCode, ShortCutButton> shortCutDic;
    #endregion

    /// <summary>
    /// 初始化函数
    /// 初始化文件路径,加载背包物品
    /// </summary>
    public void Init()
    {
        shortCutList = new List<ShortCutButton>();
        shortCutDic = new Dictionary<KeyCode, ShortCutButton>();
        LoadShortCutInfo();
        Stage.inst.onKeyDown.Add(OnShortCutDown);
    }

    private void LoadShortCutInfo()
    {
        shortCutInfoList = shortCutManagerDAL.LoadShortCutInfo();
        for (int i = 0; i < shortCutInfoList.Count; i++)
        {
            ShortCutButton sc = (ShortCutButton)UIPackage.CreateObject("MainMenu", "SlotButton");
            sc.ShortCutInfo = shortCutInfoList[i];
            sc.Skillinfo = SkillManager.Instance.GetsKillByID(sc.ShortCutInfo.SkillID);
            if (sc.Skillinfo != null)
            {
                sc.icon = sc.Skillinfo.SkillSprite;
            }
            sc.title = i.ToString();
            sc.data = i;
            sc.onDrop.Add(OnDrop);
            shortCutList.Add(sc);
            shortCutDic.Add((KeyCode)Enum.Parse(typeof(KeyCode), "Alpha" + (i + 1)), sc);
        }
    }
    /// <summary>
    /// 将快捷栏信息显示在快捷栏中
    /// </summary>
    /// <param name="shortCutButtonList">快捷栏列表</param>
    public void SetShortCutToList(GList shortCutButtonList)
    {
        for (int i = 0; i < shortCutList.Count; i++)
        {
            shortCutButtonList.AddChild(shortCutList[i]);
        }
    }
    /// <summary>
    /// 保存快捷栏中的信息
    /// </summary>
    public void SaveShortCut()
    {
        shortCutManagerDAL.SaveShortCutInfo(shortCutInfoList);
    }
    /// <summary>
    /// 拖拽释放
    /// </summary>
    /// <param name="context"></param>
    private void OnDrop(EventContext context)
    {
        int i = Int32.Parse(((GButton)context.sender).data.ToString());
        //ShortCutList[i-1].icon = (string)context.data;
        try
        {
            SkillListItem si = (SkillListItem)context.data;
            //foreach (var item in shortCutList)
            //{
            //    if(item.Skillinfo== si.SkillInfo)
            //        return;
            //}
            shortCutList[i].ShortCutInfo.SkillID = si.SkillInfo.SkillID;
            shortCutList[i].Skillinfo = si.SkillInfo;
            shortCutList[i].icon = si.Icon.icon;
        }
        catch (Exception)
        {
        }
    }
    private void OnShortCutDown(EventContext context)
    {
        
        ShortCutButton scb = null;
        
        if (shortCutDic.TryGetValue(context.inputEvent.keyCode,out scb))
        {
            if (scb.Skillinfo == null)
            {
                return;
            }
            scb.Skillinfo.UseSkill(GameObject.FindGameObjectWithTag("Player").transform);
        }
    }
}