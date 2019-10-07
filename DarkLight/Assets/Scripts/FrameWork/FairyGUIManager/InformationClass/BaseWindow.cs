using UnityEngine;
using System.Collections;
using FairyGUI;
/// <summary>
/// window几类
/// </summary>
public class BaseWindow:Window
{
    #region 数据成员
    //window信息类
    public WindowInfo windowInfo;
    //window中的动效
    private Transition _transition;
    public Transition Tran
    {
        get
        {
            return _transition;
        }

        set
        {
            _transition = value;
        }
    }
    //window中的控制器
    private Controller _controller;
    public Controller Con
    {
        get
        {
            return _controller;
        }

        set
        {
            _controller = value;
        }
    }
    //在该界面上层打开界面时屏蔽该界面点击的遮罩
    private GGroup _mask;
    public GGroup Mask
    {
        get
        {
            return _mask;
        }

        set
        {
            _mask = value;
        }
    }
    //切换界面时呈现动画的遮罩
    private GGraph _changeMask;
    public GGraph ChangeMask
    {
        get
        {
            return _changeMask;
        }

        set
        {
            _changeMask = value;
        }
    }

    #endregion

    /// <summary>
    /// 为windowInfo赋值
    /// </summary>
    /// <param name="oldWindow"></param>
    public void Copy(WindowInfo oldWindow)
    {
        windowInfo = new WindowInfo();
        windowInfo.PackageName = oldWindow.PackageName;
        windowInfo.WindowName = oldWindow.WindowName;
        windowInfo.UIWindowType = oldWindow.UIWindowType;
    }

    /// <summary>
    /// 设置窗体主组件
    /// </summary>
    /// <param name="view"></param>
    public void SetWindowView(GComponent view)
    {
        this.contentPane = view;
    }
    /// <summary>
    /// 创建前期 主要用于寻找view上的组件
    /// </summary>
    public virtual void OnBeforeEnter()
    {
        
    }

    /// <summary>
    /// 创建成功 主要用于逻辑注册
    /// </summary>
    public virtual void OnEnter()
    {
        
    }

    /// <summary>
    /// 当在该界面上再打开界面时,暂停该界面
    /// </summary>
    /// 
    public virtual void OnPause()
    {
    }

    /// <summary>
    /// 当在关闭该界面上打开的界面时,恢复该界面
    /// </summary>
    public virtual void OnResume()
    {
    }

    /// <summary>
    /// 当暂时隐藏这个界面时
    /// </summary>
   public virtual void OnConceal()
    {

    }

    /// <summary>
    /// 当暂时隐藏后重新打开界面时
    /// </summary>
    public virtual void OnShow()
    {

    }

    /// <summary>
    /// 界面关闭之前
    /// </summary>
    public virtual void OnBeforeClose()
    {
    }

    /// <summary>
    /// 界面关闭
    /// </summary>
    public virtual void OnClose()
    {
    }
}