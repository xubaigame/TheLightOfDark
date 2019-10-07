using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInfo
{
    #region 数据成员
    //格子编号
    private int slotID;
    public int SlotID
    {
        get
        {
            return slotID;
        }

        set
        {
            slotID = value;
        }
    }

    //ItemID
    private int itemID;
    public int ItemID
    {
        get
        {
            return itemID;
        }

        set
        {
            itemID = value;
        }
    }

    //格子当前物品数量
    private int itemCount;
    public int ItemCount
    {
        get
        {
            return itemCount;
        }

        set
        {
            itemCount = value;
        }
    }

    #endregion

    public void Copy(SlotInfo s)
    {
        SlotID = s.SlotID;
        ItemID = s.ItemID;
        ItemCount = s.ItemCount;
        
    }
}
