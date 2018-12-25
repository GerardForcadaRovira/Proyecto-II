using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController2 : MonoBehaviour {

    float InputX;
    float InputY;

    private Rigidbody rb;

    public float speed = 10;

	// Use this for initialization
	void Start () {
        rb = this.gameObject.GetComponent<Rigidbody>();
   	}
	
	// Update is called once per frame
	void Update () {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");

	}

    
}
