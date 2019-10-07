using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;

public class StartMenuWindow : BaseWindow {
    GImage gliterImage;
    GGroup StartButtonGroup;
    GButton NewGameButton;
    GButton LoadGameButton;
    GImage StartBG;
    public override void OnBeforeEnter()
    {
        Stage.inst.onKeyDown.Add(OnKeyDown);
        this.contentPane.MakeFullScreen();
        StartBG = this.contentPane.GetChild("StartBG").asImage;
        StartBG.MakeFullScreen();
        Tran = this.contentPane.GetTransition("Glitter");
        gliterImage = this.contentPane.GetChild("GlitterImage").asImage;
        this.contentPane.GetTransition("SceneStart").Play();
        StartButtonGroup = this.contentPane.GetChild("StartButton").asGroup;
        NewGameButton = this.contentPane.GetChild("NewGameButton").asButton;
        LoadGameButton = this.contentPane.GetChild("LoadGameButton").asButton;
        NewGameButton.onClick.Add(OnNewGameButtonDown);
        LoadGameButton.onClick.Add(OnLoadGameButtonDown);
        StartButtonGroup.visible = false;
    }
    public override void OnEnter()
    {
        Show();
    }
    public override void OnClose()
    {
        base.OnClose();
        this.contentPane.Dispose();
    }
    private void OnNewGameButtonDown()
    {
        UIWindowManager.Instance.CloseWindow(UIWindowTypes.StartMenuWindow);
        UIWindowManager.Instance.OpenWindow(UIWindowTypes.SelectMenuWindow);
    }
    private void OnLoadGameButtonDown()
    {
        UIWindowManager.Instance.CloseWindow(UIWindowTypes.StartMenuWindow);
        SceneManager.LoadScene(1);
    }
    void OnKeyDown(EventContext context)
    {
        Tran.Stop();
        gliterImage.visible = false;
        StartButtonGroup.visible = true;
    }
}
