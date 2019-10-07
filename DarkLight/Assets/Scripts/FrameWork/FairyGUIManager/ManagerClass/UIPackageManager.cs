using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine.Networking;
/// <summary>
/// FairyGUI的包的管理类
/// </summary>

public class UIPackageManager:SingLeton<UIPackageManager>
{
    #region 数据成员
    //记录包是否Add的字典
    private Dictionary<string, bool> packageAddDict = new Dictionary<string, bool>();
    #endregion


    /// <summary>
    /// 将一个UI包add进来
    /// </summary>
    /// <param name="packageName">UI包名</param>
    public void AddPackage(string packageName)
    {
        if (CheckPackageHaveAdd(packageName) == false)
        {
            //AssetBundle ab = AssetBundle.LoadFromFile(Application.dataPath + "/AssetBundles/fgui/" + packageName.ToLower() + ".ab");
            //UIPackage.AddPackage(ab);
            UIPackage.AddPackage("FairyGUI/" + packageName + "/" + packageName);
            packageAddDict.Add(packageName, true);
        }
    }
    /// <summary>
    /// 检查UI包是否已经包进来
    /// </summary>
    /// <param name="packageName">UI包名</param>
    public bool CheckPackageHaveAdd(string packageName)
    {
        return packageAddDict.ContainsKey(packageName);
    }

    /// <summary>
    /// 清理没有用到的UI包
    /// </summary>
    public void ClearNotUsePackage()
    {
       
    }
}