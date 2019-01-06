using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elemento
{
    public class PlayerController : MonoBehaviour
    {

        #region Variables
        [Header("Movement Settings:")]
        public float speed;
        public float jumpForce;

        [Header("Physics:")]
        public float fallMultiplier = 2.5f;
        public LayerMask discludePlayer;
        public Transform raycastPosition;
        private bool grounded;

        //References
        [Header("References:")]
        public GameObject projectile1;
        private Rigidbody rb;
        private SphereCollider spColl;

        [Header("References:")]
        public Animator anim;

        //Utilities
        float horizontalInput, verticalInput;
        Vector3 movementDirection, velocity;
        bool playerMoving;
        #endregion

        #region Core
        // Use this for initialization
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody>();
            spColl = gameObject.GetComponent<SphereCollider>();
        }

        // Update is called once per frame
        void Update()
        {
            GroundChecking();
            Jump();
            Move();
            Combat();
            Animate();
        }
        #endregion

        #region Movement
        private void Move()
        {
            //Get Inputs
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            //Generate direction vector
            movementDirection = new Vector3(horizontalInput, 0, verticalInput);

            //Is the player moving?
            velocity = new Vector3(horizontalInput, 0, verticalInput);

            if (velocity != Vector3.zero)
                playerMoving = true;
            else
                playerMoving = false;

            //Modify move vector
            if (verticalInput > 0)
                movementDirection = transform.forward;
            else if (verticalInput < 0)
                movementDirection = -transform.forward;

            if (horizontalInput > 0)
                movementDirection = transform.right;
            else if (horizontalInput < 0)
                movementDirection = -transform.right;

            //Add force in direction with speed
            rb.AddForce(movementDirection * speed * Time.deltaTime, ForceMode.Force);
        }

        private void Jump()
        {
            if (grounded && Input.GetButton("Jump"))
            {
                anim.SetTrigger("Jump");
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        #endregion

        #region Animations
        //Function charged of animating the player following certain inputs
        private void Animate()
        {
            anim.SetFloat("Speed", velocity.z);
            anim.SetFloat("Direction", velocity.x);
            anim.SetBool("IsMoving", playerMoving);
            anim.SetBool("IsGrounded", grounded);
        }
        #endregion

        #region Utilities
        private void FixedUpdate()
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
        }

        private void GroundChecking()
        {

            bool touches = Physics.Raycast(raycastPosition.transform.position, Vector3.down, 0.3f, discludePlayer);

            if (touches)
                grounded = true;
            else
                grounded = false;

            Debug.DrawRay(raycastPosition.transform.position, Vector3.down * 0.3f, Color.red);
        }
        #endregion

        #region Combat
        private void Combat()
        {
            //Check inputs
            if (Input.GetButton("Fire1"))
            {
                //Play animation
                anim.SetTrigger("Spell1");
                StartCoroutine(CastSpell());
            }
        }

        IEnumerator CastSpell()
        {
            yield return new WaitForSeconds(1.0f);

            //Cast projectile
            Instantiate(projectile1, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0f), transform.rotation);
        }
        #endregion
    }
}