using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class EquipMenuWindow : BaseWindow {
    private List<GLoader> equipmentList;
    public override void OnBeforeEnter()
    {
        equipmentList = new List<GLoader>();
        equipmentList.Add(contentPane.GetChild("Headgear").asLoader);
        equipmentList.Add(contentPane.GetChild("Accessory").asLoader);
        equipmentList.Add(contentPane.GetChild("Right").asLoader);
        equipmentList.Add(contentPane.GetChild("Left").asLoader);
        equipmentList.Add(contentPane.GetChild("Armor").asLoader);
        equipmentList.Add(contentPane.GetChild("Shoe").asLoader);
        closeButton.onClick.Add(() => { UIWindowManager.Instance.HideWindow(UIWindowTypes.EquipMenuWindow); });
        EquipmentManager.Instance.UpdateUI += UpdateUI;
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
        EquipmentManager.Instance.SetSlotToList(equipmentList);
    }
}
