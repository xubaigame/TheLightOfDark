using LitJson;
using System;
using System.Data;

public class Quest:BaseItem
{
    public Quest(DataRow item)
    {
        ItemID = int.Parse(item["item_id"].ToString());
        Name = item["item_name"].ToString();
        ItemQuality = (ItemQualitys)Enum.Parse(typeof(ItemQualitys), item["item_quality"].ToString());
        ItemType = (ItemTypes)Enum.Parse(typeof(ItemTypes), item["item_type"].ToString());
        PlayerType = (PlayerTypes)Enum.Parse(typeof(PlayerTypes), item["player_type"].ToString());
        Des = item["item_description"].ToString();
        Capacity = int.Parse(item["item_capacity"].ToString());
        BuyPrice = int.Parse(item["item_buyprice"].ToString());
        SellPrice = int.Parse(item["item_sellprice"].ToString());
        Sprite = item["item_sprite"].ToString();
    }
}
