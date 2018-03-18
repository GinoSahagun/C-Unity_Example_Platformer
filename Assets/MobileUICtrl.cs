using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Routes the Mobile Inputs to the Correct Methods inside the Player Ctrl Script
/// </summary>

public class MobileUICtrl : MonoBehaviour {

    public GameObject Player;
    PlayerCtrl playerCtrl;

	// Use this for initialization
	void Start () {

        playerCtrl = Player.GetComponent<PlayerCtrl>();
        

	}
	
    public void MobileMoveLeft()
    {
        playerCtrl.MobileMoveLeft();
    }
    public void MobileMoveRight()
    {
        playerCtrl.MobileMoveRight();
    }
    public void MobileStop()
    {
        playerCtrl.MobileStop();
    }
    public void MobileFireBullets()
    {
        playerCtrl.MobileFireBullets();
    }
    public void MobileJump()
    {
        playerCtrl.MobileJump();
    }
}
