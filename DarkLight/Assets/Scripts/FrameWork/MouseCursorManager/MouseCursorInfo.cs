using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorInfo
{
    private string name;
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
    public MouseCursorTypes MouseCursorType
    {
        get
        {
            return mouseCursorType;
        }

        set
        {
            mouseCursorType = value;
        }
    }

    private MouseCursorTypes mouseCursorType;

    private string texTurePath;
    public string TexTurePath
    {
        get
        {
            return texTurePath;
        }

        set
        {
            texTurePath = value;
        }
    }
}
