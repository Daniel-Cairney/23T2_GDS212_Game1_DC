using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DanielCairney
{
    public class PlayerMovement : MonoBehaviour
    {
        //[Header("Player Health")]
        //public float Health = 100f;

        [Header("Movement")]
        public float moveSpeed;

        public float groudDrag;

        public float jumpForce;
        public float jumpCooldown;
        public float airMultiplier;
        bool readyToJump;

        [Header("Keybinds")]
        public KeyCode jumpKey = KeyCode.Space;

        [Header("Ground Check")]
        public float playerHeight;
        public LayerMask whatIsGround;
        bool grounded;

        public Transform orientation;

        float horizontalInput;
        float verticalInput;

        Vector3 moveDirection;


        Rigidbody rb;

        private void Start()
        {
            rb= GetComponent<Rigidbody>();
            rb.freezeRotation= true;
            readyToJump = true; 
        }

        private void Update()
        {
            //Ground check
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

            MyInput();
            SpeedControl();

            //handle drag
            if (grounded)
                rb.drag= groudDrag;
            else 
                rb.drag= 0;
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }
        private void MyInput()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            //when to jump
            if(Input.GetKey(jumpKey) && readyToJump && grounded)
            {
                readyToJump= false;

                Jump();

                Invoke(nameof(ResetJump), jumpCooldown); 
            }
        }
        
        private void MovePlayer()
        {
            //calculate movement direction 
            moveDirection = orientation.forward * verticalInput + orientation.right* horizontalInput;

            //on ground
            if(grounded)
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

            //in air
            else if(!grounded)
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
        
        private void SpeedControl()
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            //Limit velocity if needed
            if(flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
        
        private void Jump()
        {
            // reset y velocity
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    
        private void ResetJump()
        {
            readyToJump = true; 
        }
    }   

}