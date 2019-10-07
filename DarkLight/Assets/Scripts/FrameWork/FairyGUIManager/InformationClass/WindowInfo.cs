using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using System;
/// <summary>
/// Window信息类,用来存储window的信息
/// </summary>
public class WindowInfo
{
    #region 数据成员
    //包名
    private string _packageName;
    public string PackageName
    {
        get
        {
            return _packageName;
        }

        set
        {
            _packageName = value;
        }
    }
    //窗体名
    private string _windowName;
    public string WindowName
    {
        get
        {
            return _windowName;
        }

        set
        {
            _windowName = value;
        }
    }
    //window类型
    private UIWindowTypes _uiWindowType;
    public UIWindowTypes UIWindowType
    {
        get
        {
            return _uiWindowType;
        }
        set
        {
            _uiWindowType = value;
        }
    }
    #endregion

    /// <summary>
    /// 获取当前窗体的包名
    /// </summary>
    /// <returns></returns>
    public string GetPackName()
    {
        return PackageName;
    }

    /// <summary>
    /// 获取当前窗体的名字
    /// </summary>
    /// <returns></returns>
    public string GetWindowName()
    {
        return WindowName;
    }
}