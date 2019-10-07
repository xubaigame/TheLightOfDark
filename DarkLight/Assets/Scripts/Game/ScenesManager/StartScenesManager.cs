using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScenesManager : GameManager {
	public List<UIWindowTypes> uiWindowTypes;
	protected  override void Awake()
	{
		base.Awake();
		SoundManager.Instance.Init();
		SoundManager.Instance.PlayBg("BGM-Ingame");
        UIConfig.tooltipsWin = "ui://ResComponent/ToolTips";
        UIWindowManager.Instance.Init(uiWindowTypes);
		UIWindowManager.Instance.OpenWindow(UIWindowTypes.LoginMenuWindow);
	}
}
