using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemInfo
{
    private int shopItemID;
    public int ShopItemID
    {
        get
        {
            return shopItemID;
        }

        set
        {
            shopItemID = value;
        }
    }

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

    private int count;
    public int Count
    {
        get
        {
            return count;
        }

        set
        {
            count = value;
        }
    }

}
