using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;
using FairyGUI;

public class MouseCursorManager : SingLeton<MouseCursorManager> {

    public MouseCursorTypes mouseCursorType;
    private List<MouseCursorInfo> mouseCursorInfoList;
    private MouseCursorDAL mouseCursorDAL = new MouseCursorDAL();
    public void Init()
    {
        mouseCursorInfoList=mouseCursorDAL.LoadMouseCursorInfoList();
    }

    public void SetMouseCorsor(MouseCursorTypes mouseCursorType)
    {
        Texture2D mouseCorsorTexture;
        string path = GetMouseCorsorTextruePath(mouseCursorType);
        if(!String.IsNullOrEmpty(path))
        {
            this.mouseCursorType = mouseCursorType;
            if (Stage.isTouchOnUI)
            {
                path = GetMouseCorsorTextruePath(MouseCursorTypes.Normal);
                mouseCorsorTexture = Resources.Load<Texture2D>(path);
                Cursor.SetCursor(mouseCorsorTexture, Vector2.zero, CursorMode.Auto);
                return;
            }
            mouseCorsorTexture = Resources.Load<Texture2D>(path);
            Cursor.SetCursor(mouseCorsorTexture,Vector2.zero,CursorMode.Auto);
        }
    }
    private string GetMouseCorsorTextruePath(MouseCursorTypes mouseCursorType)
    {
        foreach (var mouseCursorInfo in mouseCursorInfoList)
        {
            if (mouseCursorInfo.MouseCursorType == mouseCursorType)
                return mouseCursorInfo.TexTurePath;
        }
        return String.Empty;
    }
}
