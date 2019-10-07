using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class CameraControl : MonoBehaviour {
	#region 数据成员
	public float initZ = 77;
	public float endZ = 107;
	public float Speed = 20;
	#endregion

	void FixedUpdate () {
		if (transform.position.z < endZ)
			transform.Translate(Vector3.forward*Speed * Time.deltaTime);
	}

}
