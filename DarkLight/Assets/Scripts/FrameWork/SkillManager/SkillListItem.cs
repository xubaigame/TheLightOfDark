using FairyGUI;
using FairyGUI.Utils;

public class SkillListItem:GComponent {
    #region 数据成员
    private BaseSkill skillInfo;
    public BaseSkill SkillInfo
    {
        get
        {
            return skillInfo;
        }

        set
        {
            skillInfo = value;
        }
    }

    private string[] skillEffect = { "增益", "增强", "单体", "群体" };
    #endregion

    public GTextField Name;
    public GTextField Effects;
    public GTextField Des;
    public GTextField Consume;
    public GLoader Icon;
    /// <summary>
    /// 重写初始化函数,加载对应组件信息
    /// </summary>
    /// <param name="xml"></param>
    override public void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        //在这里继续你的始化
        Icon= GetChild("icon").asLoader;
        Name = GetChild("Name").asTextField;
        Effects = GetChild("Effect").asTextField;
        Des = GetChild("Des").asTextField;
        Consume = GetChild("Consume").asTextField;
    }
    public void SetValues()
    {
        Icon.icon = SkillInfo.SkillSprite;
        Name.text= SkillInfo.SkillName;
        Effects.text = skillEffect[(int)SkillInfo.SkillType];
        Des.text = SkillInfo.SkillDes;
        Consume.text = SkillInfo.SkillMP.ToString();
    }
}
