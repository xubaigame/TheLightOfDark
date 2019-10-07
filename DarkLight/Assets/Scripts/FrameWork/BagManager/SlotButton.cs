using FairyGUI;

public class SlotButton :GButton
{
    #region 数据成员
    private SlotInfo slotInfo;
    public SlotInfo SlotInfo
    {
        get
        {
            return slotInfo;
        }

        set
        {
            slotInfo = value;
        }
    }
    //格子中的物品信息
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
    #endregion
}
