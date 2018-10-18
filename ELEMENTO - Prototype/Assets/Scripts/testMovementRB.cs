using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMovementRB : MonoBehaviour {

    //Animations
    Animator anim;

    //Movement
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;
    Rigidbody playerRB;
    public LayerMask groundLayers;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        playerCollider = this.GetComponent<CapsuleCollider>();
        playerRB = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //Inputs
        float horizontal = Input.GetAxis("Horizontal");
       
        float vertical = Input.GetAxis("Vertical");
        Debug.Log(isGrounded());

        anim.SetFloat("Speed", vertical);

        if (vertical >= 0.5)
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
        }

        if (vertical <= -0.5)
        {
            transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && vertical == 0.0f)
        {
            StartCoroutine(jump());
        } else if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && vertical >= 0.5)
        {
            StartCoroutine(jump2());
        }

        if (horizontal >= 0.3)
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }

        if (horizontal <= -0.3)
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }

    }

    bool isGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y, playerCollider.bounds.center.z), playerCollider.radius * .9f, groundLayers);
    }

    IEnumerator jump()
    {
        anim.SetTrigger("Jump");
        yield return new WaitForSeconds(0.5f);
        playerRB.AddForce(Vector3.up, ForceMode.Impulse);
    }

    IEnumerator jump2()
    {
        anim.SetTrigger("Jump");
        yield return new WaitForSeconds(0.5f);
        playerRB.AddForce(Vector3.up, ForceMode.Impulse);
    }
}
