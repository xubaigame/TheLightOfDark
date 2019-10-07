using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMenuWindow : BaseWindow
{
    GButton QuitGameButton;
    GButton MuteButton;
    GButton CloseButton;
    int mute;
    public override void OnBeforeEnter()
    {
        QuitGameButton = this.contentPane.GetChild("QuitGameButton").asButton;
        CloseButton = this.contentPane.GetChild("frame").asCom.GetChild("closeButton").asButton;
        CloseButton.onClick.Add(() => { UIWindowManager.Instance.HideWindow(windowInfo.UIWindowType); });
        MuteButton = this.contentPane.GetChild("SoundButton").asButton;

        QuitGameButton.onClick.Add(() => {
#if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;
#else

            Application.Quit();
#endif
        });
            Con = MuteButton.GetController("button");
        mute = PlayerPrefs.GetInt("Sound");
        Con.selectedIndex = mute == 1 ? 0 : 1;
        SoundManager.Instance.Mute = mute == 1 ? false : true;
        MuteButton.onClick.Add(OnMuteButonDown);
    }

    public override void OnEnter()
    {
        this.contentPane.SetPosition((float)(GRoot.inst.width * 0.7), (float)(GRoot.inst.height * 0.5 - contentPane.width), contentPane.position.z - contentPane.height);
        Show();
    }
    public override void OnResume()
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
    private void OnMuteButonDown()
    {
        if(mute==1)
        {
            PlayerPrefs.SetInt("Sound", 0);
            mute = 0;
            Con.selectedIndex = mute == 1 ? 0 : 1;
            SoundManager.Instance.Mute = true;
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            mute = 1;
            Con.selectedIndex = mute == 1 ? 0 : 1;
            SoundManager.Instance.Mute = false ;
        }
    }
}
