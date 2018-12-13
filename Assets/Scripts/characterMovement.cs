using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class characterMovement : MonoBehaviour {

    #region Variables
    Animator anim;
    CharacterController controller;
    #endregion

    [System.Serializable]
    public class AnimationsSettings
    {
        public string verticalVelocityFloat = "Forward";
        public string horizontalVelocityFloat = "Strafe";
        public string groundedBool = "isGrounded";
        public string jumpBool = "isJumping";
    }
    [SerializeField]
    public AnimationsSettings animations;

    [System.Serializable]
    public class PhysicsSettings
    {
        public float gravityModifier = 9.81f;
        public float baseGravity = 50.0f;
        public float resetGravityValue = 1.2f;

    }
    [SerializeField]
    public PhysicsSettings physics;

    [System.Serializable]
    public class MovementSettings
    {
        public float jumpSpeed = 6f;
        public float jumpTime = 0.25f;
    }
    [SerializeField]
    public MovementSettings movement;

    private bool jumping;
    private bool resetGravity;
    float gravity;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
        SetupAnimator();
	}
	
	// Update is called once per frame
	void Update () {
        ApplyGravity();
        Animate(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

       
	}

    public void Jump()
    {
        if (jumping)
        {
            return;
        }

        if (controller.isGrounded)
        {
            jumping = true;
            StartCoroutine(StopJump());
        }
    }

    IEnumerator StopJump()
    {
        yield return new WaitForSeconds(movement.jumpTime);
        jumping = false;
    }

    private void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            if (!resetGravity)
            {
                gravity = physics.resetGravityValue;
                resetGravity = true;
            }
            gravity += Time.deltaTime * physics.gravityModifier;
        }
        else
        {
            gravity = physics.baseGravity;
            resetGravity = false;
        }

        Vector3 gravityVector = new Vector3();
        if (!jumping)
        {
            gravityVector.y -= gravity;
        }
        else
        {
            gravityVector.y = movement.jumpSpeed;
        }

        controller.Move(gravityVector * Time.deltaTime);
    }

    //Animates the character and root motion handles the movement
    public void Animate(float forward, float strafe)
    {
        anim.SetFloat(animations.verticalVelocityFloat, forward);
        anim.SetFloat(animations.horizontalVelocityFloat, strafe);
        anim.SetBool(animations.groundedBool, controller.isGrounded);
        anim.SetBool(animations.jumpBool, jumping);
    }

    //Setup  the animator with child avatar
    private void SetupAnimator()
    {
        Animator[] animators = gameObject.GetComponentsInChildren<Animator>();

        if (animators.Length > 0)
        {
            for (int i = 0; i < animators.Length; i++)
            {
                Animator animm = animators[i];
                Avatar av = animm.avatar;

                if (animm != anim)
                {
                    anim.avatar = av;
                    Destroy(animm);
                }
            }
        }
    }
}
