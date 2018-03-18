using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Make Camera Follow the Player
/// </summary>
public class CameraCtrl : MonoBehaviour {

    public Transform player;
    public float yOffSet;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(player.transform.position.x, (yOffSet + player.transform.position.y), transform.position.z);

	}
}
