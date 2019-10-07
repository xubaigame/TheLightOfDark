using LitJson;
using System;
using System.Data;
using System.Text;

public class Equipment: BaseItem
{
    #region 数据成员
    //攻击力
    private int attack;
    public int Attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }
    //防御力
    private int defence;
    public int Defence
    {
        get
        {
            return defence;
        }

        set
        {
            defence = value;
        }
    }
    //移动速度
    private int speed;
    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }
    //装备部位
    private EquipmentTypes equipmentType;
    public EquipmentTypes EquipmentType
    {
        get
        {
            return equipmentType;
        }

        set
        {
            equipmentType = value;
        }
    }
    #endregion
    public Equipment(DataRow item)
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
        EquipmentType = (EquipmentTypes)Enum.Parse(typeof(EquipmentTypes), item["equipment_type"].ToString());
        Attack = int.Parse(item["item_attack"].ToString());
        Defence = int.Parse(item["item_defence"].ToString());
        Speed= int.Parse(item["item_speed"].ToString());
    }
    public override string GetToolTipText()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("[color=#FFFFFF]" + Name + "[/color]" + "\n");
        sb.AppendFormat("[color=#FFFFFF]" + Des + "[/color]" + "\n");
        sb.AppendFormat("[color=#FFFFFF]Attack:+" + Attack + "[/color]" + "\n");
        sb.AppendFormat("[color=#FFFFFF]Defence:+" + Defence + "[/color]" + "\n");
        sb.AppendFormat("[color=#FFFFFF]Speed:+" + Speed + "[/color]" + "\n");
        sb.AppendFormat("[color=#FFFFFF]格子容量:" + Capacity + "[/color]" + "\n");
        sb.AppendFormat("[color=#FFFFFF]购买价格:" + BuyPrice + "[/color]" + "\n");
        sb.AppendFormat("[color=#FFFFFF]出售价格:" + SellPrice + "[/color]" + "\n");
        return sb.ToString();
    }

    /// <summary>
    /// 使用装备
    /// </summary>
    /// <param name="init">是否为初始化函数</param>
    /// <param name="addItem">是否添加装备(false为卸载装备)</param>
    public override void UseItem(bool init=false,bool addItem = true)
    {
        if(addItem)
        {
            if(!init)
                EquipmentManager.Instance.AddEquipment(ItemID, EquipmentType);
            WareEquipment();
        }
        else
        {
            RemoveAddEquipment();
        }
    }
    private void WareEquipment()
    {
        PlayerStatusManager.Instance.AddTotal(Attack, Defence, Speed,0);
    }
    private void RemoveAddEquipment()
    {
        PlayerStatusManager.Instance.AddTotal(-Attack, -Defence, -Speed,0);
    }
}