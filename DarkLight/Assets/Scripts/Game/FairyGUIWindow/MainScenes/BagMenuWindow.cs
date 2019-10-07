using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class BagMenuWindow : BaseWindow {
    private GList SlotList;
    private GTextField moneyText;
    public override void OnBeforeEnter()
    {
        closeButton.onClick.Add(() => { UIWindowManager.Instance.HideWindow(UIWindowTypes.BagMenuWindow); });
        SlotList = contentPane.GetChild("SlotList").asList;
        moneyText = contentPane.GetChild("CoinNumber").asTextField;
        BagManager.Instance.SetSlotToList(SlotList);
        PlayerStatusManager.Instance.UpdateUI += UpdateUI;
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
        moneyText.text = PlayerStatusManager.Instance.playerInfo.Money.ToString();
    }
    
}
