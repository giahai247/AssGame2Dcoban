using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	private Transform player;

	// Use this for initialization
	void Start () {
		//anh xa
		player = GameObject.Find("player_ini").transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			// vi tri ban dau
			Vector3 pos = transform.position;

			// lay vi tri hien tai cua player
			pos.x = player.position.x;

			// cap nhat vi tri moi
			transform.position = pos;
		}
	}
}
