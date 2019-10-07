using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using LitJson;
using System;

/// <summary>
/// UI界面的管理类
/// </summary>

public class UIWindowManager:SingLeton<UIWindowManager>
{
    #region 数据成员
    //界面栈,控制界面的显示与隐藏
    Stack<BaseWindow> UIStack = new Stack<BaseWindow>();
    //临时数组,存储已经被实例化的面板
    List<BaseWindow> windowDict = new List<BaseWindow>();
    //存储所有的面板
    private List<BaseWindow> windowList=new List<BaseWindow>();

    #endregion
    /// <summary>
    /// 初始化FairyGUI的管理器
    /// 将带有脚本的物体实例化至面板并将脚本存储
    /// </summary>
    /// <param name="uiWindowTypes">该界面要实例化的界面类型</param>
    public void Init(List<UIWindowTypes> uiWindowTypes)
    {
        TextAsset ta = Resources.Load<TextAsset>("FairyGUI/Config/WindowInformation");
        List<WindowInfo> windowInfos = JsonMapper.ToObject<List<WindowInfo>>(ta.text);
        foreach (var item in windowInfos)
        {
           
            if (item.UIWindowType == UIWindowTypes.Resources)
            {
                UIPackageManager.Instance.AddPackage(item.PackageName);
            }
            else 
            {
                foreach (UIWindowTypes uitype in uiWindowTypes)
                {
                    if (item.UIWindowType == uitype)
                    {
                        UIPackageManager.Instance.AddPackage(item.PackageName);
                        Type type = Type.GetType(item.WindowName);
                        object obj = type.Assembly.CreateInstance(type.Name);
                        BaseWindow bw = obj as BaseWindow;
                        bw.Copy(item);
                        windowList.Add(bw);
                        break;
                    }  
                }
            }
        }

    }

    /// <summary>
    /// 通过UIWindowType获取WindowInfo
    /// </summary>
    /// <param name="uiWindowType">窗体类型</param>
    /// <returns>该窗体的信息</returns>
    public BaseWindow GetWindowInfo(UIWindowTypes uiWindowType)
    {
        foreach (var item in windowList)
        {
            if (item.windowInfo.UIWindowType == uiWindowType)
                return item;
        }
        return null;
    }
    /// <summary>
    /// 打开界面
    /// </summary>
    public void OpenWindow(UIWindowTypes uiWindowType)
    {
        
        BaseWindow bw = null;
        if (UIStack.Count > 0)
        {
            bw = UIStack.Peek();
            bw.OnPause();
        }
        if (windowDict.Contains(GetWindowInfo(uiWindowType)))
        {
            bw = GetWindowInfo(uiWindowType);
            UIStack.Push(bw);
            bw.OnShow();
        }
        else
        {
            bw = GetWindowInfo(uiWindowType);
            GComponent view = UIPackage.CreateObject(bw.windowInfo.GetPackName(), bw.windowInfo.GetWindowName()).asCom;
            windowDict.Add(bw);
            bw.SetWindowView(view);
            UIStack.Push(bw);
            bw.OnBeforeEnter();
            bw.OnEnter();
        }
    }

    /// <summary>
    /// 暂时隐藏界面界面
    /// </summary>
    public void HideWindow(UIWindowTypes uiWindowType)
    {
        
        BaseWindow bw = GetWindowInfo(uiWindowType);
        if (windowDict.Contains(bw))
        {
            while(true)
            {
                bw = UIStack.Pop();
                bw.OnConceal();
                if (bw.windowInfo.UIWindowType == uiWindowType)
                    break;
            }
            if (UIStack.Count >= 1)
            {
                bw = UIStack.Peek();
                bw.OnResume();
            }
        }
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    /// <param name="uiWindowType"></param>
    public void CloseWindow(UIWindowTypes uiWindowType)
    {
        BaseWindow bw = GetWindowInfo(uiWindowType);
        if (windowDict.Contains(bw))
        {
            while (true)
            {
				bw = UIStack.Pop();
                bw.OnBeforeClose();
                bw.OnClose();
                if (bw.windowInfo.UIWindowType == uiWindowType)
                    break;
            }
            if (UIStack.Count >= 1)
            {
                bw = UIStack.Peek();
                bw.OnResume();
            }
        }
    }
}