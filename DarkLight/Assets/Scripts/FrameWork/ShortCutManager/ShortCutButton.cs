using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class ShortCutButton : GButton {

    private ShortCutInfo shortCutInfo;
    public ShortCutInfo ShortCutInfo
    {
        get
        {
            return shortCutInfo;
        }

        set
        {
            shortCutInfo = value;
        }
    }


    private BaseSkill skillinfo;
    public BaseSkill Skillinfo
    {
        get
        {
            return skillinfo;
        }

        set
        {
            skillinfo = value;
        }
    }
}
