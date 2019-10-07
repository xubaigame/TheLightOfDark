using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
/// <summary>
/// 单例模板类
/// </summary>
/// <typeparam name="T">需要单例的类型</typeparam>
public abstract class MonoSingleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    #region 数据成员
    //静态私有成员
    private static T m_instance = null;
    //静态共有属性
    public static T Instance
    {
        get { return m_instance; }
    }
    #endregion

    /// <summary>
    /// 在Awake中完成单例模式的赋值
    /// </summary>
    protected virtual void Awake()
    {
        m_instance = this as T;
    }
}