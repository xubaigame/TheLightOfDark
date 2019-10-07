using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 游戏管理类
/// 若你的游戏中只有一个界面,请使用它进行初始化操作
/// 若游戏中存在多个场景,请创建对应场景的管理类并继承自GameManager,子类需重写Awake方法
/// </summary>
public class GameManager : MonoSingleton<GameManager>
{
    public void Play(double seconds, Action Method)
    {
        StartCoroutine(PlayerMethod(seconds, Method));
    }
    private IEnumerator PlayerMethod(double seconds, Action Method)
    {
        yield return new WaitForSeconds((float)seconds);
        if (Method != null)
            Method();
    }
}
