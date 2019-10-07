using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using FairyGUI;
using System;

public class BagManager : SingLeton<BagManager>
{
    #region 数据成员
    BagManagerDAL bagManagerDAL = new BagManagerDAL();
    //物品信息列表
    List<SlotInfo> slotsList;
    //格子列表
    private List<SlotButton> buttonList;
    //拖拽起始位置
    private int startSlotId;
    //默认ToolTips的值
    private string dToolTips = "这个格子空空如也,请去商店购买道具放在这里吧";
    #endregion

    /// <summary>
    /// 初始化函数
    /// 初始化文件路径,加载背包物品
    /// </summary>
    public void Init()
    {
        slotsList = bagManagerDAL.LoadBagInfo();
        buttonList = new List<SlotButton>();
        LoadSlot();
    }

    /// <summary>
    /// 加载背包中物品中的信息
    /// </summary>
    private void LoadSlot()
    {
        for (int i = 0; i < slotsList.Count; i++)
        {
            SlotButton sb = (SlotButton)UIPackage.CreateObject("BagMenu", "SlotButton");
            sb.SlotInfo = slotsList[i];
            sb.Item = ItemManager.Instance.GetItemByID(sb.SlotInfo.ItemID);
            sb.draggable = true;
            sb.data = i;
            sb.onClick.Add(OnMouseButtonDown);
            sb.onDragStart.Add(OnDragStart);
            sb.onDrop.Add(OnDrop);
            if (sb.Item != null)
            {
                sb.icon = sb.Item.Sprite;
                if (sb.Item.Capacity != 1)
                    sb.title = sb.SlotInfo.ItemCount.ToString();
                sb.tooltips = sb.Item.GetToolTipText();
            }
            else
            {
                sb.tooltips = dToolTips;
            }
            buttonList.Add(sb);

        }
    }

    private void OnMouseButtonDown(EventContext context)
    {
        int i = Int32.Parse(((SlotButton)context.sender).data.ToString());
        BaseItem bs = buttonList[i].Item;
        if (buttonList[i].SlotInfo.ItemCount>1)
        {
            buttonList[i].SlotInfo.ItemCount -= 1;
        }
        else
        {
            buttonList[i].Item = null;
            buttonList[i].SlotInfo.ItemID = -1;
            buttonList[i].SlotInfo.ItemCount = 0;

            buttonList[i].icon = null;
            buttonList[i].tooltips = dToolTips;
            buttonList[i].title = null;
        }
        if (buttonList[i].SlotInfo.ItemCount > 1)
        {
            buttonList[i].title = buttonList[i].SlotInfo.ItemCount.ToString();
        }
        else
        {
            buttonList[i].title = null;
        }
        if(bs!=null)
            bs.UseItem();
    }

    /// <summary>
    /// 将背包物品显示在UI中
    /// </summary>
    /// <param name="slotList"></param>
    public void SetSlotToList(GList slotList)
    {
        for (int i = 0; i < slotsList.Count; i++)
        {
            slotList.AddChild(buttonList[i]);
        }
    }

    /// <summary>
    /// 保存背包中的信息
    /// </summary>
    public void SaveSlot()
    {
        bagManagerDAL.SaveLoadBagInfo(slotsList);
    }
    /// <summary>
    /// 向背包中添加物品
    /// </summary>
    /// <param name="itemID">物品序号</param>
    /// <param name="rcount">未成功添加的物品数量</param>
    /// <param name="count">要添加的物品数量</param>
    public void AddItemToSlot(int itemID,out int rcount, int count = 1)
    {
        BaseItem bi = ItemManager.Instance.GetItemByID(itemID);
        if (bi == null)
        {
            rcount = 0;
            return;
        }
        else
        {
            int RateCount=FindSameSlot(itemID, count);
            if(RateCount==0)
            {
                rcount = 0;
                return;
            }
            else if(RateCount<count)
            {
                rcount = RateCount;
                return;
            }
            else
            {
                rcount =FindNullSlot(itemID, count);
                return;
            }



        }
    }

    /// <summary>
    /// 寻找相同的物品的格子
    /// </summary>
    /// <param name="itemID">物品序号</param>
    /// <param name="count">要添加的物品数量</param>
    /// <returns></returns>
    public int FindSameSlot(int itemID, int count)
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (buttonList[i].SlotInfo.ItemID == itemID && buttonList[i].SlotInfo.ItemCount + count <= buttonList[i].Item.Capacity)
            {
                buttonList[i].SlotInfo.ItemCount += count;
                if(buttonList[i].Item.Capacity!=1)
                    buttonList[i].title = buttonList[i].SlotInfo.ItemCount.ToString();
                return 0;
            }
            else if(buttonList[i].SlotInfo.ItemID == itemID&& buttonList[i].SlotInfo.ItemCount < buttonList[i].Item.Capacity)
            {
                int add = buttonList[i].Item.Capacity - buttonList[i].SlotInfo.ItemCount;
                buttonList[i].SlotInfo.ItemCount += add;
                if (buttonList[i].Item.Capacity != 1)
                    buttonList[i].title = buttonList[i].SlotInfo.ItemCount.ToString();
                count -= add;
                return FindNullSlot(itemID,count);
            }
        }
        return count;
    }

    /// <summary>
    /// 寻找空格子
    /// </summary>
    /// <param name="itemID">物品序号</param>
    /// <param name="mes">添加信息</param>
    /// <param name="count">要添加的物品数量</param>
    /// <returns></returns>
    public int FindNullSlot(int itemID, int count )
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (buttonList[i].Item == null)
            {
                buttonList[i].Item = ItemManager.Instance.GetItemByID(itemID);
                buttonList[i].icon = buttonList[i].Item.Sprite;
                buttonList[i].tooltips = buttonList[i].Item.GetToolTipText();
                buttonList[i].SlotInfo.ItemID = itemID;
                if(count<= buttonList[i].Item.Capacity)
                {
                    buttonList[i].SlotInfo.ItemCount = count;
                    if (buttonList[i].Item.Capacity != 1)
                        buttonList[i].title = buttonList[i].SlotInfo.ItemCount.ToString();
                    return 0;
                }
                else
                {
                    buttonList[i].SlotInfo.ItemCount = buttonList[i].Item.Capacity;
                    if (buttonList[i].Item.Capacity != 1)
                        buttonList[i].title = buttonList[i].SlotInfo.ItemCount.ToString();
                    return FindNullSlot(itemID,count- buttonList[i].Item.Capacity);
                }
                
            }
        }
        return count;
    }

    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="context"></param>
    private void OnDragStart(EventContext context)
    {
        SlotButton sb=(SlotButton)context.sender;  
        startSlotId = sb.SlotInfo.SlotID;
        context.PreventDefault();
        //DragDropManager.inst.StartDrag(sb, sb.icon, sb.icon, (int)context.data);
        DragDropManager.inst.StartDrag(sb, sb.icon, sb, (int)context.data);
    }

    /// <summary>
    /// 拖拽释放
    /// </summary>
    /// <param name="context"></param>
    private void OnDrop(EventContext context)
    {
        try
        {
            SlotButton sb = (SlotButton)context.sender;
            if (sb.Item == null)
            {
                //对当前格子进行赋值
                sb.Item = buttonList[startSlotId].Item;
                sb.SlotInfo.ItemID = buttonList[startSlotId].SlotInfo.ItemID;
                sb.SlotInfo.ItemCount = buttonList[startSlotId].SlotInfo.ItemCount;
                //对格子的显示属性赋值
                sb.title = buttonList[startSlotId].title;
                sb.icon = (string)context.data;
                sb.tooltips = buttonList[startSlotId].tooltips;
                //置空原始格子
                buttonList[startSlotId].Item = null;
                buttonList[startSlotId].SlotInfo.ItemID = -1;
                buttonList[startSlotId].SlotInfo.ItemCount = 0;
                //清除原始格子的显示属性
                buttonList[startSlotId].icon = null;
                buttonList[startSlotId].title = "";
                buttonList[startSlotId].tooltips = dToolTips;

            }
            else
            {
                //创建临时格子
                SlotButton temp = new SlotButton();
                temp.SlotInfo = new SlotInfo();
                //将要当前的格子信息赋值到临时格子
                temp.Item = sb.Item;
                temp.SlotInfo.ItemID = sb.SlotInfo.ItemID;
                temp.SlotInfo.ItemCount = sb.SlotInfo.ItemCount;
                temp.title = sb.title;
                temp.icon = sb.icon;
                temp.tooltips = sb.tooltips;
                //将拖拽格子复制到当前格子
                sb.Item = buttonList[startSlotId].Item;
                sb.SlotInfo.ItemID = buttonList[startSlotId].SlotInfo.ItemID;
                sb.SlotInfo.ItemCount = buttonList[startSlotId].SlotInfo.ItemCount;
                sb.title = buttonList[startSlotId].title;
                sb.icon = buttonList[startSlotId].icon;
                sb.tooltips = buttonList[startSlotId].tooltips;
                //将临时格子中的信息赋值到拖拽格子
                buttonList[startSlotId].Item = temp.Item;
                buttonList[startSlotId].SlotInfo.ItemID = temp.SlotInfo.ItemID;
                buttonList[startSlotId].SlotInfo.ItemCount = temp.SlotInfo.ItemCount;
                buttonList[startSlotId].title = temp.title;
                buttonList[startSlotId].icon = temp.icon;
                buttonList[startSlotId].tooltips = temp.tooltips;
            }

        }
        catch (Exception)
        {
        }
    }
}
