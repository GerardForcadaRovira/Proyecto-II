using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    CharacterController controller;
    public float speed;
    public float verticalVelocity;

    private Vector3 moveDirection;
    public float gravityScale;

    private Animator anim;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;

        moveDirection = new Vector3(x, moveDirection.y, z);

        if (controller.isGrounded)
        {
            moveDirection.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetTrigger("Jump");
                moveDirection.y = verticalVelocity;
                Debug.Log("Jumping");
            }
        }

        
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);
        anim.SetFloat("Speed", z);
    }
}
