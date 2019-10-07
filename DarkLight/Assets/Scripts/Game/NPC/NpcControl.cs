using UnityEngine;


public class NpcControl : MonoBehaviour {

	#region 数据成员
	//NPC的类型
	public NpcType type;
	//玩家的位置信息
	private Transform player;
	#endregion

	/// <summary>
	/// 获取玩家位置组件
	/// </summary>
	private void Start()
	{
		player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Transform>();
	}

	private void OnMouseOver()
	{
        if (Vector3.Distance(this.transform.position, player.position) < 10) 
        {
            MouseCursorManager.Instance.SetMouseCorsor(MouseCursorTypes.NpcTalk);
            if (Input.GetMouseButtonDown(0))
            {
                if (Vector3.Distance(this.transform.position, player.position) < 10)
                {
                    if (type == NpcType.TaskNPC)
                    {
                        UIWindowManager.Instance.OpenWindow(UIWindowTypes.TaskMenuWindow);
                    }
                    else if (type == NpcType.PotionNPC)
                    {
                        ShopManager.Instance.itemType = ItemTypes.Consumable;
                        UIWindowManager.Instance.OpenWindow(UIWindowTypes.ShopMenuWindow);
                    }
                    else
                    {
                        ShopManager.Instance.itemType = ItemTypes.Equipment;
                        UIWindowManager.Instance.OpenWindow(UIWindowTypes.ShopMenuWindow);
                    }
                }
            }
        }

    }
	private void OnMouseExit()
	{
		MouseCursorManager.Instance.SetMouseCorsor(MouseCursorTypes.Normal);
	}
}
