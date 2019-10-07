using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem
{
    #region 数据成员
    //唯一标识
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

    //物品名称
    private string name;
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    //物品类型
    private ItemTypes itemType;
    public ItemTypes ItemType
    {
        get
        {
            return itemType;
        }

        set
        {
            itemType = value;
        }
    }

    //物品品质
    private ItemQualitys itemQuality;
    public ItemQualitys ItemQuality
    {
        get
        {
            return itemQuality;
        }

        set
        {
            itemQuality = value;
        }
    }

    //物品所属职业
    private PlayerTypes playerType;
    public PlayerTypes PlayerType
    {
        get
        {
            return playerType;
        }

        set
        {
            playerType = value;
        }
    }
    //物品描述
    private string des;
    public string Des
    {
        get
        {
            return des;
        }

        set
        {
            des = value;
        }
    }

    //格子容量
    private int capacity;
    public int Capacity
    {
        get
        {
            return capacity;
        }

        set
        {
            capacity = value;
        }
    }

    //购买价格,-1表示无法购买
    private int buyPrice;
    public int BuyPrice
    {
        get
        {
            return buyPrice;
        }

        set
        {
            buyPrice = value;
        }
    }

    //出售价格
    private int sellPrice;
    public int SellPrice
    {
        get
        {
            return sellPrice;
        }

        set
        {
            sellPrice = value;
        }
    }

    //显示图片的存储路径
    private string sprite;
    public string Sprite
    {
        get
        {
            return sprite;
        }

        set
        {
            sprite = value;
        }
    }

    #endregion

    /// <summary>
    /// 获取物品提示信息
    /// </summary>
    /// <returns></returns>
    public virtual string GetToolTipText()
    {
        return String.Empty;
    }

    /// <summary>
    /// 获取物品效果信息
    /// </summary>
    /// <returns></returns>
    public virtual string GetEffectText()
    {
        return String.Empty;
    }

    /// <summary>
    /// 使用装备
    /// </summary>
    /// <param name="init">是否为初始化函数</param>
    /// <param name="addItem">是否添加装备(false为卸载装备)</param>
    public virtual void UseItem(bool init = false, bool addItem = true)
    {

    }
}
