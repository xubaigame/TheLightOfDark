using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour {

    #region 数据成员
    public GameObject[] CharacterList;
    private GameObject[] Characters;
    private int length;
    public int Index = 0;
    #endregion

    /// <summary>
    /// 初始化角色数组
    /// </summary>
    public void Init()
    {
        length = CharacterList.Length;
        Characters = new GameObject[length];
        for (int i = 0; i < length; i++)
        {
            Characters[i] = Instantiate(CharacterList[i], this.transform.position, transform.rotation);
            Characters[i].transform.SetParent(this.transform);
        }
        UpdateCharacter();
    }

    /// <summary>
    /// 更新模型显示
    /// </summary>
    private void UpdateCharacter()
    {
        for (int i = 0; i < length; i++)
        {
            if (i != Index && Characters[i].activeSelf == true)
            {
                Characters[i].SetActive(false);
            }
            else if(i==Index)
            {
                Characters[i].SetActive(true);
            }
        }
    }
    public void OnNextButtonDown()
    {
        Index++;
        Index %= length;
        UpdateCharacter();
    }
    public void OnPrevButtonDown()
    {
        Index--;
        if (Index < 0)
            Index += length;
        UpdateCharacter();
    }
}
