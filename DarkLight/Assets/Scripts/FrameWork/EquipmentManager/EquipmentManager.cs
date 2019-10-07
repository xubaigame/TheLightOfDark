using FairyGUI;
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EquipmentManager : SingLeton<EquipmentManager> {

    #region 数据成员
    private EquipmentManagerDAL equipmentManager = new EquipmentManagerDAL();
    //物品信息列表
    List<EquipmentInfo> equipmentList;

    public Action UpdateUI;
    #endregion

    /// <summary>
    /// 初始化函数
    /// 初始化文件路径,加载装备面板物品
    /// </summary>
    public void Init()
    {
        LoadSlot();
    }

    /// <summary>
    /// 加载装备面板中的物品信息
    /// </summary>
    private void LoadSlot()
    {
        equipmentList = equipmentManager.LoadEquipmentInfo();
        foreach (var item in equipmentList)
        {
            BaseItem bs = ItemManager.Instance.GetItemByID(item.ItemID);
            if(bs!=null)
                bs.UseItem(true);
        }
    }

    /// <summary>
    /// 将装备物品显示在UI中
    /// </summary>
    /// <param name="slotList">装备面板的装备槽列表</param>
    public void SetSlotToList(List<GLoader> list )
    {
        for (int i = 0; i < list.Count; i++)
        {
            foreach (var item in equipmentList)
            {
                if(list[i].name== item.EquipmentType.ToString())
                {
                    BaseItem bs = ItemManager.Instance.GetItemByID(item.ItemID);
                    if (bs != null)
                    {
                        list[i].icon = bs.Sprite;
                        list[i].tooltips = bs.GetToolTipText();
                        list[i].data = i;
                        list[i].onClick.Add(OnMouseButtonClick);
                    }
                    else
                    {
                        list[i].icon = null;
                        list[i].tooltips = null;
                    }
                    break;
                }
            }
        }
    }
    /// <summary>
    /// 保存装备面板中的信息
    /// </summary>
    public void SaveEquipment()
    {
        equipmentManager.SaveEquipmentInfo(equipmentList);
    }

    private void OnMouseButtonClick(EventContext context)
    {
        int i = Int32.Parse(((GLoader)context.sender).data.ToString());
        RemoveEquipment(i);
        StartEvent();
    }

    public void StartEvent()
    {
        if (UpdateUI != null)
            UpdateUI();
    }

    public void AddEquipment(int itemID,EquipmentTypes equipmentType)
    {
        for (int i = 0; i < equipmentList.Count; i++)
        {
            if(equipmentList[i].EquipmentType== equipmentType)
            {
                if(equipmentList[i].ItemID==-1)
                {
                    equipmentList[i].ItemID = itemID;
                }
                else
                {
                    RemoveEquipment(i);
                    equipmentList[i].ItemID = itemID;
                }
            }
            StartEvent();
        }
    }

    public void RemoveEquipment(int index)
    {
        int coun;
        BagManager.Instance.AddItemToSlot(equipmentList[index].ItemID, out coun);
        if (coun == 1)
            return;
        ItemManager.Instance.GetItemByID(equipmentList[index].ItemID).UseItem(false,false);
        equipmentList[index].ItemID = -1;
    }
}
