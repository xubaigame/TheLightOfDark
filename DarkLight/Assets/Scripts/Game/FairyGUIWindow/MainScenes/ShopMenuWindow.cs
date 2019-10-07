using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuWindow : BaseWindow {

    private GList ShopList;
    public override void OnBeforeEnter()
    {
        closeButton.onClick.Add(() => { UIWindowManager.Instance.HideWindow(UIWindowTypes.ShopMenuWindow); });
        ShopList = contentPane.GetChild("ShopList").asList;
        ShopManager.Instance.SetShopItemToList(ShopList);
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
        ShopManager.Instance.SetShopItemToList(ShopList);
        Show();
    }
    public override void OnPause()
    {
    }
    public override void OnResume()
    {
    }
}
