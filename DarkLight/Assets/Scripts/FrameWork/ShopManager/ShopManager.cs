using FairyGUI;
using LitJson;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using UnityEngine;
public class ShopManager : SingLeton<ShopManager> {

	#region 数据成员
	//格子信息列表
	List<ShopItemInfo> shopItemInfoList;
	//格子列表
	private List<ShopListItem> shopItemList;
    public ItemTypes itemType;
    #endregion

    /// <summary>
    /// 初始化函数,加载文件路径
    /// </summary>
    public void Init()
	{
		shopItemInfoList = new List<ShopItemInfo>();
		shopItemList = new List<ShopListItem>();
        string sql = "select * from shop_item_information";
        DataTable dt = MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if(dt.Rows.Count>0)
        {
            foreach (DataRow item in dt.Rows)
            {
                ShopItemInfo shopItemInfo = new ShopItemInfo();
                shopItemInfo.ShopItemID = int.Parse(item["shop_item_id"].ToString());
                shopItemInfo.ItemID= int.Parse(item["item_id"].ToString());
                shopItemInfo.Count = int.Parse(item["shop_item_count"].ToString());
                shopItemInfoList.Add(shopItemInfo);
            }  
        }
        for (int i = 0; i < shopItemInfoList.Count; i++)
		{
			ShopListItem si = (ShopListItem)UIPackage.CreateObject("ShopMenu", "ShopListItem");
			si.ShopItemInfo = shopItemInfoList[i];
			si.Item = ItemManager.Instance.GetItemByID(si.ShopItemInfo.ItemID);
			if (si.Item != null)
			{
				si.SetValues();
				si.AddCountButton.data = i;
				si.CutCountButton.data = i;
				si.BuyButton.data = i;
				si.AddCountButton.onClick.Add(OnAddCountButtonDown);
				si.CutCountButton.onClick.Add(OnCutCountButtonDown);
				si.BuyButton.onClick.Add(OnBuyButtonDown);
			}
			shopItemList.Add(si);
		}
	}

	/// <summary>
	/// 显示商品列表信息
	/// </summary>
	/// <param name="shopList"></param>
	public void SetShopItemToList(GList shopList)
	{
        shopList.RemoveChildren();
        if (itemType==ItemTypes.Consumable)
		{
			for (int i = 0; i < shopItemInfoList.Count; i++)
			{
                if (shopItemList[i].Item.ItemType == itemType)
                    shopList.AddChild(shopItemList[i]); 
			}
		}
        else if(itemType == ItemTypes.Equipment)
        {
            for (int i = 0; i < shopItemInfoList.Count; i++)
            {
                if (shopItemList[i].Item.ItemType == itemType&& (shopItemList[i].Item.PlayerType==PlayerStatusManager.Instance.playerInfo.PlayerType|| shopItemList[i].Item.PlayerType==PlayerTypes.Commom))
                    shopList.AddChild(shopItemList[i]);
            }
        }
	}

	private void OnBuyButtonDown(EventContext context)
	{
		int i = Int32.Parse(((GButton)context.sender).data.ToString());
		int count = shopItemList[i].ShopItemInfo.Count;
		int sellPrice = shopItemList[i].Item.SellPrice;
		int rcount;
		if (PlayerStatusManager.Instance.HaveMoney(count * sellPrice))
		{
			
			BagManager.Instance.AddItemToSlot(shopItemList[i].Item.ItemID, out rcount, shopItemList[i].ShopItemInfo.Count);
			if(rcount==0)
			{
				PlayerStatusManager.Instance.CutMoney(count * sellPrice);
			}
			else
			{
				PlayerStatusManager.Instance.CutMoney((count-rcount) * sellPrice);
			}
			shopItemList[i].Count.text = 0.ToString();
            shopItemList[i].ShopItemInfo.Count = 0;

        }
	}
	private void OnAddCountButtonDown(EventContext context)
	{
		int i = Int32.Parse(((GButton)context.sender).data.ToString());
		int count = shopItemList[i].ShopItemInfo.Count+1;
		int sellPrice = shopItemList[i].Item.SellPrice;
		if (PlayerStatusManager.Instance.HaveMoney(count* sellPrice))
		{
			shopItemList[i].Count.text = (++shopItemList[i].ShopItemInfo.Count).ToString();
		}
	}
	private void OnCutCountButtonDown(EventContext context)
	{
		int i = Int32.Parse(((GButton)context.sender).data.ToString());
		int count = shopItemList[i].ShopItemInfo.Count-1;
		int sellPrice = shopItemList[i].Item.SellPrice;
		if (count<0)
		{
			shopItemList[i].Count.text = 0.ToString();
            shopItemList[i].ShopItemInfo.Count = 0;
        }
		else if(PlayerStatusManager.Instance.HaveMoney(count * sellPrice))
		{
			shopItemList[i].Count.text = (--shopItemList[i].ShopItemInfo.Count).ToString();
		}
	}
}
