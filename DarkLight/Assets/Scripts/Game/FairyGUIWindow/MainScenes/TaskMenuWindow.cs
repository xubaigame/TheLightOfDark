using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;

public class TaskMenuWindow : BaseWindow {
    GTextField Des;
    GComponent descom;
    GButton AcceptButton;
    GButton CancelButton;
    GButton CloseButton;
    GButton FinishButton;
    public override void OnBeforeEnter()
    {
        AcceptButton = this.contentPane.GetChild("AcceptButton").asButton;
        CancelButton = this.contentPane.GetChild("CancelButton").asButton;
        FinishButton = this.contentPane.GetChild("FinishButton").asButton;
        descom = this.contentPane.GetChild("Des").asCom;
        Des = descom.GetChild("Des").asTextField;
        CloseButton = this.contentPane.GetChild("frame").asCom.GetChild("closeButton").asButton;
        CloseButton.onClick.Add(() => { UIWindowManager.Instance.HideWindow(windowInfo.UIWindowType); });
        AcceptButton.onClick.Add(OnAcceptButtonDown);
        CancelButton.onClick.Add(OnCancelButtonDown);
        FinishButton.onClick.Add(OnFinishButtonDown);
        TaskManager.Instance.UpdateUI += UpdateUI;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (TaskManager.Instance.GetTaskState())
        {
            AcceptButton.visible = true;
            CancelButton.visible = false;
            FinishButton.visible = false;
        }
        else
        {
            AcceptButton.visible = false;
            CancelButton.visible = true;
            FinishButton.visible = true;
        }
        Des.text = TaskManager.Instance.currentTask.ShowTaskInfo();
    }
    public override void OnEnter()
    {
        this.contentPane.SetPosition((float)(GRoot.inst.width * 0.7), (float)(GRoot.inst.height * 0.5- contentPane.width), contentPane.position.z - contentPane.height);
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
    private void OnAcceptButtonDown()
    {
        TaskManager.Instance.AcceptTask();
    }
    private void OnCancelButtonDown()
    {
        TaskManager.Instance.CancelTask();
    }
    private void OnFinishButtonDown()
    {
        TaskManager.Instance.FinishTask();

        UIWindowManager.Instance.HideWindow(windowInfo.UIWindowType);
    }
}
