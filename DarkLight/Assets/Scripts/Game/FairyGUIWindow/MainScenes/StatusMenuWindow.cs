using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class StatusMenuWindow : BaseWindow {
    GTextField attack;
    GTextField def;
    GTextField speed;
    GTextField remain;
    GTextField total;
    GButton AddAttackButton;
    GButton AddDefButton;
    GButton AddSpeedButton;
    public override void OnBeforeEnter()
    {
        closeButton.onClick.Add(() => { UIWindowManager.Instance.HideWindow(UIWindowTypes.StatusMenuWindow); });
        attack = contentPane.GetChild("Attack").asTextField;
        def = contentPane.GetChild("Defense").asTextField;
        remain = contentPane.GetChild("RemainPoint").asTextField;
        speed = contentPane.GetChild("Speed").asTextField;
        total = contentPane.GetChild("Total").asTextField;
        AddAttackButton = contentPane.GetChild("AddAttackButton").asButton;
        AddDefButton = contentPane.GetChild("AddDefButton").asButton;
        AddSpeedButton = contentPane.GetChild("AddSpeedButton").asButton;
        AddAttackButton.onClick.Add(()=> { PlayerStatusManager.Instance.OnAttackButtonDown(); });
        AddDefButton.onClick.Add(
            () => { PlayerStatusManager.Instance.OnDefButtonDown(); });
        AddSpeedButton.onClick.Add(
            () => { PlayerStatusManager.Instance.OnSpeedButtonDown(); });
        PlayerStatusManager.Instance.UpdateUI += UpdateUI;
        UpdateUI();


    }
    public override void OnEnter()
    {
        this.contentPane.SetPosition((GRoot.inst.width / 2- contentPane.width/2), (GRoot.inst.height / 2- contentPane.height/2), 0);
        
        Show();
    }
    public override void OnConceal()
    {
        Hide();
    }
    public override void OnPause()
    {
    }
    public override void OnResume()
    {
    }
    public override void OnShow()
    {
        Show();
    }
    public override void OnBeforeClose()
    {
        PlayerStatusManager.Instance.UpdateUI -= UpdateUI;
    }
    private void UpdateUI()
    {
        attack.text = PlayerStatusManager.Instance.GetAttack().ToString();
        def.text = PlayerStatusManager.Instance.GetDefence();
        speed.text = PlayerStatusManager.Instance.GetSpeed();
        remain.text = (PlayerStatusManager.Instance.playerInfo.RemainPoint).ToString();
        total.text = PlayerStatusManager.Instance.GetTotal();
        if(PlayerStatusManager.Instance.playerInfo.RemainPoint>0)
        {
            AddAttackButton.enabled = true;
            AddDefButton.enabled = true;
            AddSpeedButton.enabled = true;
        }
        else
        {
            AddAttackButton.enabled = false;
            AddDefButton.enabled = false;
            AddSpeedButton.enabled = false;
        }
    }
}
