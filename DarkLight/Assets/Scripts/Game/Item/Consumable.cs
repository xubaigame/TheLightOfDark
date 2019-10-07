using System.Text;
using LitJson;
using System;
using System.Data;

public class Consumable:BaseItem
{
    #region 数据成员
    //恢复的血量
    private int hp;
    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    //恢复的蓝量
    private int mp;
    public int Mp
    {
        get
        {
            return mp;
        }

        set
        {
            mp = value;
        }
    }
    #endregion

    public Consumable(DataRow item)
    {
        ItemID = int.Parse(item["item_id"].ToString());
        Name = item["item_name"].ToString();
        ItemQuality = (ItemQualitys)Enum.Parse(typeof(ItemQualitys), item["item_quality"].ToString());
        ItemType = (ItemTypes)Enum.Parse(typeof(ItemTypes), item["item_type"].ToString());
        PlayerType= (PlayerTypes)Enum.Parse(typeof(PlayerTypes), item["player_type"].ToString());
        Des = item["item_description"].ToString();
        Capacity = int.Parse(item["item_capacity"].ToString());
        BuyPrice = int.Parse(item["item_buyprice"].ToString());
        SellPrice = int.Parse(item["item_sellprice"].ToString());
        Sprite = item["item_sprite"].ToString();
        Hp = int.Parse(item["item_hp"].ToString());
        Mp = int.Parse(item["item_mp"].ToString());
    }

    public override string GetToolTipText()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("[color=#FFFFFF]" + Name + "[/color]" +"\n");
        sb.AppendFormat("[color=#FFFFFF]" + Des + "[/color]" + "\n");
        sb.AppendFormat("[color=#FFFFFF]HP:+" + Hp + "[/color]" + "\n");
        sb.AppendFormat("[color=#FFFFFF]MP:+" + Mp + "[/color]" + "\n");
        sb.AppendFormat("[color=#FFFFFF]格子容量:" + Capacity + "[/color]" + "\n");
        sb.AppendFormat("[color=#FFFFFF]购买价格:" + BuyPrice + "[/color]" + "\n");
        sb.AppendFormat("[color=#FFFFFF]出售价格:" + SellPrice + "[/color]" + "\n");
        return sb.ToString();
    }

    public override string GetEffectText()
    {
        if (Mp == 0)
            return ("HP: +" + Hp);
        else if (Hp == 0)
            return ("MP: +" + Mp);
        else
            return String.Empty;
    }
    public override void UseItem(bool init = false, bool addItem = true)
    {
        PlayerStatusManager.Instance.AddHP_MP(Hp, Mp);
    }
}