using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;

public class MainScenesManager : GameManager
{
    public List<UIWindowTypes> uiWindowTypes;
    public GameObject[] Players;
    protected override void Awake()
    {
        base.Awake();
        SoundManager.Instance.Init();
        UIConfig.tooltipsWin = "ui://ResComponent/ToolTips";
        UIConfig.bringWindowToFrontOnClick = false;
        UIObjectFactory.SetPackageItemExtension("ui://BagMenu/SlotButton", typeof(SlotButton));
        UIObjectFactory.SetPackageItemExtension("ui://ShopMenu/ShopListItem", typeof(ShopListItem));
        UIObjectFactory.SetPackageItemExtension("ui://SkillMenu/SkillListItem", typeof(SkillListItem));
        UIObjectFactory.SetPackageItemExtension("ui://MainMenu/SlotButton", typeof(ShortCutButton));
        UIWindowManager.Instance.Init(uiWindowTypes);
        PlayerStatusManager.Instance.Init();
        GameObject.Instantiate(Players[(int)(PlayerStatusManager.Instance.playerInfo.PlayerType)-1]);
        MouseCursorManager.Instance.Init();
        TaskManager.Instance.Init();
        ItemManager.Instance.Init();
        EnemyManager.Instance.Init();
        BagManager.Instance.Init();
        ShopManager.Instance.Init();
        EquipmentManager.Instance.Init();
        SkillManager.Instance.Init();
        ShortCutManager.Instance.Init();
        SoundManager.Instance.PlayBg("BGM-Ingame");
        UIWindowManager.Instance.CloseWindow(UIWindowTypes.SelectMenuWindow);
        UIWindowManager.Instance.OpenWindow(UIWindowTypes.MainMenuWindow);
    }
    /*private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int cout;
            BagManager.Instance.AddItemToSlot(Random.Range(0, 9), out cout);
        }
    }*/
    public void Update()
    {
    }
    private void OnDestroy()
    {
        TaskManager.Instance.SaveTask();
        PlayerStatusManager.Instance.SavePlayerStatusInfo();
        BagManager.Instance.SaveSlot();
        EquipmentManager.Instance.SaveEquipment();
        ShortCutManager.Instance.SaveShortCut();
    }
    
}
