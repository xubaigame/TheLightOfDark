using FairyGUI;
using FairyGUI.Utils;

public class ShopListItem :GComponent
{
    #region 数据成员
    private ShopItemInfo shopItemInfo;
    public ShopItemInfo ShopItemInfo
    {
        get
        {
            return shopItemInfo;
        }

        set
        {
            shopItemInfo = value;
        }
    }
    private BaseItem item;
    public BaseItem Item
    {
        get
        {
            return item;
        }

        set
        {
            item = value;
        }
    }

    public GLoader Icon;
    public GTextField Name;
    public GTextField Effect;
    public GTextField Money;
    public GTextField Count;
    public GButton BuyButton;
    public GButton AddCountButton;
    public GButton CutCountButton;
    #endregion

    /// <summary>
    /// 重写初始化函数,加载对应组件信息
    /// </summary>
    /// <param name="xml"></param>
    override public void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);

        //在这里继续你的始化
        Icon = GetChild("icon").asLoader;
        Name = GetChild("Name").asTextField;
        Effect = GetChild("Effect").asTextField;
        Money = GetChild("Money").asTextField;
        Count = GetChild("Count").asTextField;
        BuyButton = GetChild("BuyButton").asButton;
        AddCountButton = GetChild("AddCountButton").asButton;
        CutCountButton = GetChild("CutCountButton").asButton;
    }
    public void SetValues()
    {
        Icon.icon = Item.Sprite;
        Name.text = Item.Name;
        Effect.text = Item.GetEffectText();
        Money.text = Item.SellPrice.ToString();
        Count.text = ShopItemInfo.Count.ToString();
        
    }
}
