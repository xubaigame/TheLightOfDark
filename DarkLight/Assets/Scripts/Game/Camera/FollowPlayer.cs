using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class FollowPlayer : MonoBehaviour {
	#region 数据成员
	bool isRoatating = false;
	Transform player;
	Vector3 offsetPos;
	float distance = 0;
	float scrollSpeed = 10;
	float rotateSpeed = 2;
	#endregion

	/// <summary>
	/// 初始化变量
	/// </summary>
	void Start () {
		player = GameObject.FindWithTag(Tags.player).GetComponent<Transform>();
		offsetPos = player.position - transform.position;

	}
	
	void Update () {
		transform.position = player.position - offsetPos;
		RoatateView();
		scrollWiew();
	}

	/// <summary>
	/// 滚轮缩放控制
	/// </summary>
	void scrollWiew()
	{
		if(!Stage.isTouchOnUI)
		{
			distance = offsetPos.magnitude;
			distance += Input.GetAxis("Mouse ScrollWheel") * -scrollSpeed;
			distance = Mathf.Clamp(distance, 2, 18);
			offsetPos = offsetPos.normalized * distance;
		}
	}

	/// <summary>
	/// 鼠标右键相机角度控制
	/// </summary>
	void RoatateView()
	{
		if(Input.GetMouseButtonDown(1))
		{
			isRoatating = true;
		}
		else if (Input.GetMouseButtonUp(1))
		{
			isRoatating = false;
		}

		if(isRoatating)
		{
			transform.RotateAround(player.position, player.up, rotateSpeed * Input.GetAxis("Mouse X"));
			Vector3 originalPos = transform.position;
			Quaternion originalRoation = transform.rotation;
			transform.RotateAround(player.position, transform.right, rotateSpeed * -Input.GetAxis("Mouse Y"));
			float x = transform.eulerAngles.x;
			if(x<10||x>80)
			{
				transform.position = originalPos;
				transform.rotation = originalRoation;
			}
		}
		offsetPos = player.position - transform.position;
	}
}
