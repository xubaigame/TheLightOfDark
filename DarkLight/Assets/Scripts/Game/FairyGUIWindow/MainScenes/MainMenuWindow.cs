using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
using DG.Tweening;

public class MainMenuWindow : BaseWindow
{
    GList ShortCutList;
    GButton BagMenuButton;
    GButton StatusMenuButton;
    GButton EquipButton;
    GButton SkillButton;
    GButton SystemButton;
    GButton MiniMapZoomInButton;
    GButton MiniMapZoomOutButton;
    GButton QuitGameButton;
    GSlider HpSlider;
    GSlider MpSlider;
    GSlider ExpSlider;
    GTextField Name;
    GTextField Lv;
    GGraph Face;
    GGraph MiniMap;
    GGroup Gameover;
    Camera MiniMapCamera;
    
    public override void OnBeforeEnter()
    {
        //获取游戏组件
        MiniMapCamera = GameObject.Find("MiniMapCamera").GetComponent<Camera>();
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 1);
            SoundManager.Instance.Mute = false;
        }
        else
        {
            int mute = PlayerPrefs.GetInt("Sound");
            SoundManager.Instance.Mute = mute == 1 ? false : true;
        }
        //获取FairyGUI组件
        this.contentPane.MakeFullScreen();
        BagMenuButton = this.contentPane.GetChild("BagButton").asButton;
        StatusMenuButton = this.contentPane.GetChild("StatusButton").asButton;
        EquipButton = this.contentPane.GetChild("EquipButton").asButton;
        SkillButton = this.contentPane.GetChild("SkillButton").asButton;
        SystemButton= this.contentPane.GetChild("SettingButton").asButton;
        ShortCutList = this.contentPane.GetChild("ShortCutList").asList;
        HpSlider = this.contentPane.GetChild("HPSlider").asSlider;
        MpSlider = this.contentPane.GetChild("MPSlider").asSlider;
        ExpSlider= this.contentPane.GetChild("ExpSlider").asSlider;
        Name = this.contentPane.GetChild("Name").asTextField;
        Lv = this.contentPane.GetChild("LV").asTextField;
        Face = this.contentPane.GetChild("Face").asGraph;
        MiniMap= this.contentPane.GetChild("MiniMap").asGraph;
        MiniMapZoomInButton = this.contentPane.GetChild("ZoomIn").asButton;
        MiniMapZoomOutButton = this.contentPane.GetChild("ZoomOut").asButton;
        Gameover = this.contentPane.GetChild("GameOver").asGroup;
        QuitGameButton = this.contentPane.GetChild("QuitGameButton").asButton;
        Mask = this.contentPane.GetChild("Mask").asGroup;
        //添加组件事件
        BagMenuButton.onClick.Add(() => { UIWindowManager.Instance.OpenWindow(UIWindowTypes.BagMenuWindow); });
        StatusMenuButton.onClick.Add(() => { UIWindowManager.Instance.OpenWindow(UIWindowTypes.StatusMenuWindow); });
        EquipButton.onClick.Add(() => { UIWindowManager.Instance.OpenWindow(UIWindowTypes.EquipMenuWindow); });
        SkillButton.onClick.Add(() => { UIWindowManager.Instance.OpenWindow(UIWindowTypes.SkillMenuWindow); });
        SystemButton.onClick.Add(() => { UIWindowManager.Instance.OpenWindow(UIWindowTypes.SystemMenuWindow); });
        MiniMapZoomInButton.onClick.Add(OnZoomInButtonDown);
        MiniMapZoomOutButton.onClick.Add(OnZoomOutButtonDown);
        QuitGameButton.onClick.Add(OnQuitGameButtonDown);
        //添加通知事件
        PlayerStatusManager.Instance.LvUP += UpdateUI;
        PlayerStatusManager.Instance.UpdateUI += UpdateUI;
        PlayerStatusManager.Instance.Death += PlayerDeath;
        //组件显示操作
        HpSlider.touchable = false;
        MpSlider.touchable = false;
        ExpSlider.touchable = false;
        Mask.visible = false;
        Gameover.visible = false;   
        ShowFace();
        ShowMiniMap();
        ShortCutManager.Instance.SetShortCutToList(ShortCutList);
        UpdateUI();
    }
    public override void OnEnter()
    {
        Show();
    }
    public override void OnPause()
    {
        //Mask.visible = true;
        //View.touchable = false;
    }
    public override void OnResume()
    {
        //Mask.visible = false;
        contentPane.RequestFocus();
        //View.touchable = false;
    }
    private void ShowFace()
    {
        Material mat;
        RenderTexture texture;
        if (PlayerStatusManager.Instance.playerInfo.PlayerType==PlayerTypes.Magician)
        {
            mat = Resources.Load<Material>("FairyGUI/MainMenu/MFaceMaterial");
            texture = Resources.Load<RenderTexture>("FairyGUI/MainMenu/MFaceTexture");
        }else
        {
            mat = Resources.Load<Material>("FairyGUI/MainMenu/SFaceMaterial");
            texture = Resources.Load<RenderTexture>("FairyGUI/MainMenu/SFaceTexture");
        }
       
        Image img = new Image();
        img.texture = new NTexture(texture);
        img.material = mat;
        Face.SetNativeObject(img);
    }
    private void ShowMiniMap()
    {
        Material mat = Resources.Load<Material>("FairyGUI/MainMenu/MiniMapMaterial");
        RenderTexture texture = Resources.Load<RenderTexture>("FairyGUI/MainMenu/MiniMapTexture");
        Image img = new Image();
        img.texture = new NTexture(texture);
        img.material = mat;
        MiniMap.SetNativeObject(img);
    }
    private void UpdateUI()
    {
        Name.text = PlayerStatusManager.Instance.playerInfo.Name;
        Lv.text = PlayerStatusManager.Instance.playerInfo.Lv.ToString();
        HpSlider.value = PlayerStatusManager.Instance.GetHpPrecent();
        MpSlider.value = PlayerStatusManager.Instance.GetMpPrecent();
        ExpSlider.value= PlayerStatusManager.Instance.GetExpPrecent();
    }
    private void OnZoomInButtonDown()
    {
        MiniMapCamera.orthographicSize -= 2;
        if (MiniMapCamera.orthographicSize < 3)
            MiniMapCamera.orthographicSize = 3;

    }
    private void OnZoomOutButtonDown()
    {
        MiniMapCamera.orthographicSize++;
        if (MiniMapCamera.orthographicSize >15)
            MiniMapCamera.orthographicSize = 15;
    }
    private void PlayerDeath()
    {
        Gameover.visible = true;
    }
    private void OnQuitGameButtonDown()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else

            Application.Quit();
#endif
    }
}
