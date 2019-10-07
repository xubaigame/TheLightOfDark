using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMenuWindow : BaseWindow
{
    GTextField Tooltips;
    GTextInput UserName;
    GTextInput UserPassWord;
    GButton LoginButton;
    public override void OnBeforeEnter()
    {
        Tooltips = this.contentPane.GetChild("Tooltips").asTextField;
        UserName = this.contentPane.GetChild("UserName").asTextInput;
        UserPassWord = this.contentPane.GetChild("UserPassWord").asTextInput;
        LoginButton = this.contentPane.GetChild("LoginButton").asButton;
        Tooltips.text = "";
        LoginButton.onClick.Add(OnLoginButtonDown);
        if(!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 1);
            SoundManager.Instance.Mute = false;
        }
        else
        {
            int mute = PlayerPrefs.GetInt("Sound");
            SoundManager.Instance.Mute = mute==1?false:true;
        }
        if(!PlayerPrefs.HasKey("Death"))
        {
            PlayerPrefs.SetInt("Death", 0);
        }
        
    }
    public override void OnEnter()
    {
        this.contentPane.SetScale(1.5f, 1.5f);
        this.contentPane.SetPosition((GRoot.inst.width / 2 - contentPane.width / 2 * 1.5f), (GRoot.inst.height / 2 - contentPane.height / 2 * 1.5f), 0);
        Show();
    }
    public override void OnClose()
    {
        base.OnClose();
        this.contentPane.Dispose();
    }
    private void OnLoginButtonDown()
    {
        if(UserName.text=="")
        {
            Tooltips.text = "账号不能为空";
            return;
        }
        else if(UserPassWord.text == "")
        {
            Tooltips.text = "密码不能为空";
            return;
        }
        UserInfo userInfo = new UserInfo();
        userInfo.UserName = UserName.text;
        userInfo.UserPwd = UserPassWord.text;
        UserInfoDAL userInfoDAL = new UserInfoDAL();
        string msg;
        bool result = userInfoDAL.Login(userInfo, out msg);
        if(result)
        {
            Tooltips.text = "登录成功";
            GameObject.Find("ScenesManager").GetComponent<GameManager>().Play(2, TrunMenu); 
        }
        else if(msg == "密码错误")
        {
            Tooltips.text = "密码错误";
        }
        else if (msg == "用户已存在")
        {
            Tooltips.text = "用户已存在";
        }
        else
        {
            int r = userInfoDAL.AddUserInfo(userInfo);
            if (r == 1)
            {
                Tooltips.text = "用户注册成功";
                GameObject.Find("ScenesManager").GetComponent<GameManager>().Play(2, TrunMenu);
            }
            else
            {
                Tooltips.text = "用户注册失败";
            }
        }
        GameConfig.UserId = userInfoDAL.GetUserID(UserName.text);
    }
    private void TrunMenu()
    {
        UIWindowManager.Instance.CloseWindow(UIWindowTypes.LoginMenuWindow);
        UIWindowManager.Instance.OpenWindow(UIWindowTypes.StartMenuWindow);
    }
}
