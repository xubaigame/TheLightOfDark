using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenuWindow : BaseWindow
{

    private GList SkillList;
    public override void OnBeforeEnter()
    {
        closeButton.onClick.Add(() => { UIWindowManager.Instance.HideWindow(UIWindowTypes.SkillMenuWindow); });
        SkillList = contentPane.GetChild("SkillList").asList;
        SkillManager.Instance.UpdateUI += UpdateUI;
        UpdateUI();
    }
    public override void OnEnter()
    {
        Show();
    }
    public override void OnConceal()
    {
        Hide();
    }
    public override void OnShow()
    {
        Show();
    }
    public override void OnPause()
    {
    }
    public override void OnResume()
    {
    }
    private void UpdateUI()
    {  
        SkillManager.Instance.SetSkillItemToList(SkillList);
    }
}
