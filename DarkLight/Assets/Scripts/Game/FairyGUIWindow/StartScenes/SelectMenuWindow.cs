using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;

public class SelectMenuWindow : BaseWindow {

    GButton NextButton;
    GButton PrevButton;
    GButton OkButton;
    GTextInput UserName;
    GGraph mask;
    CharacterSpawn cs;
    PlayerInfoDAL playerInfoDAL = new PlayerInfoDAL();
    TaskInfoDAL taskInfoDAL = new TaskInfoDAL();
    BagManagerDAL bagManagerDAL = new BagManagerDAL();
    EquipmentManagerDAL equipmentManagerDAL = new EquipmentManagerDAL();
    ShortCutManagerDAL shortCutManagerDAL = new ShortCutManagerDAL();
    public override void OnBeforeEnter()
    {
        this.contentPane.MakeFullScreen();
        cs = GameObject.Find("Character Spawn").GetComponent<CharacterSpawn>();
        cs.Init();
        NextButton = this.contentPane.GetChild("NextButton").asButton;
        PrevButton = this.contentPane.GetChild("PrevButton").asButton;
        OkButton = this.contentPane.GetChild("OkButton").asButton;
        UserName = this.contentPane.GetChild("UserName").asTextInput;
        mask = this.contentPane.GetChild("Mask").asGraph;
        mask.visible = false;
        Tran = this.contentPane.GetTransition("ChangeScene");
        OkButton.onClick.Add(OnOkButtonDown);
        NextButton.onClick.Add(cs.OnNextButtonDown);
        PrevButton.onClick.Add(cs.OnPrevButtonDown);
    }
    public override void OnEnter()
    {
        Show();
    }
    private void OnOkButtonDown()
    {
        mask.visible = true;
        Tran.Play();
        GameManager.FindObjectOfType<GameManager>().Play(0.5f, CreateNewPlayer);
       
    }

    private void CreateNewPlayer()
    {
        playerInfoDAL.DeleteOldPlayer();
        GameConfig.playerTypes = (PlayerTypes)(cs.Index + 1);
        GameConfig.PlayerName = UserName.text;
        cs.gameObject.SetActive(false);
        playerInfoDAL.CreateNewPlayer();
        taskInfoDAL.CreateOneTask();
        bagManagerDAL.CreateNewPlayer();
        equipmentManagerDAL.CreateNewPlayer();
        shortCutManagerDAL.CreateNewPlayer();
        SceneManager.LoadScene(1);
    }
    public override void OnClose()
    {
        this.contentPane.Dispose();
    }
}
