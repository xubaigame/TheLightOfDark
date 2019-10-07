using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFllow : MonoBehaviour {

	Transform player;
	float  offsetPos_x;
    float offsetPos_z;
    bool isRoatating = false;
    float rotateSpeed = 2;
    void Start () {
		player = GameObject.FindWithTag(Tags.player).GetComponent<Transform>();
		offsetPos_x = (player.position - transform.position).x;
        offsetPos_z = (player.position - transform.position).z;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.position.x - offsetPos_x, transform.position.y, player.position.z - offsetPos_z);
        RoatateView();
    }
    void RoatateView()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRoatating = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isRoatating = false;
        }

        if (isRoatating)
        {
            transform.RotateAround(player.position, player.up, rotateSpeed * Input.GetAxis("Mouse X"));
        }
    }
}
