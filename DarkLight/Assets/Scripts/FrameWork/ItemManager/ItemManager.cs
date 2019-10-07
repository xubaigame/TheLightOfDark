using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;
using MySql.Data.MySqlClient;
using System.Data;

public class ItemManager : SingLeton<ItemManager> {

    private List<BaseItem> itemsList;
    public void Init()
    {
        itemsList = new List<BaseItem>();
        BaseItem baseItem = null;
        string sql = "select * from item_information";
        
        DataTable dt= MysqlHelper.ExecuteTable(sql, CommandType.Text, null);
        if(dt.Rows.Count>0)
        {
            foreach (DataRow item in dt.Rows)
            {
                Type type = Type.GetType(item["item_type"].ToString());
                object[] parameters = new object[1];
                parameters[0] = item;
                object obj = Activator.CreateInstance(type, parameters);
                baseItem = obj as BaseItem;
                itemsList.Add(baseItem);
            }
        }
    }
    public BaseItem GetItemByID(int itemID)
    {
        foreach (var item in itemsList)
        {
            if (item.ItemID == itemID)
                return item;
        }
        return null;
    }
}
