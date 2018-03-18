using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour {

    // Use this for initialization
    public float Delay;
	void Start () {
        Destroy(gameObject, Delay);
	}
	
}
