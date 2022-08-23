using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Proiect.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private Transform PlayerTransform;
        [SerializeField]
        private Transform CameraOrient;
        [SerializeField, Range(0, 1000)] private float movementSpeed;
        // [SerializeField] private CharacterController _characterController;
        private float turnSmoothTime = 0.05f;
        private float turnSmoothVelocity;
        private Rigidbody body;
        private Vector3 velocity;
        private KeyCode jumpKey = KeyCode.Space;
        private int moveState = 0;
        private bool CanJump = false;
        private float fallVelocity = 0f;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        void Start()
        {
            var playerTransformRotation = PlayerTransform.rotation;
            playerTransformRotation.y = CameraOrient.rotation.y;
            PlayerTransform.rotation = playerTransformRotation;
        }
        
        void Update()
        {
            if (Input.GetKeyDown(jumpKey))
            {
                JumpPlayer();
            }
        }

        void MovePlayer()
        {
            
            Vector2 playerInput;
            Vector3 direction;
            playerInput.x = Input.GetAxis("Horizontal");
            playerInput.y = Input.GetAxis("Vertical");
            direction = new Vector3(playerInput.x, 0f, playerInput.y).normalized;
            if (direction.magnitude >= 0.1f)
            {
                
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + CameraOrient.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                    turnSmoothTime);
                this.transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                velocity = movementSpeed * moveDir.normalized;
                body.AddForce(velocity, ForceMode.Acceleration);
                // _characterController.Move(Time.deltaTime * movementSpeed * moveDir.normalized);
                // body.velocity += velocity*Time.deltaTime;
            }
            
        }

        private void FixedUpdate()
        {
            
            //Moving the player on every fixed update
            MovePlayer();
            body.velocity += new Vector3(0f, -9.81f*3, 0f)*Time.deltaTime;
            RegisterFallVelocity();
        }

        //Handling player jumping
        void JumpPlayer()
        {
            if (CanJump == true)
            {
                // body.velocity += movementSpeed*(Vector3.up/2);
                body.AddForce(movementSpeed*(Vector3.up.normalized/2), ForceMode.Impulse);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            CheckFallVelocity();
            fallVelocity = 0f;
        }

        private void OnCollisionStay(Collision collisionInfo)
        {
            //Making sure the player can always jump while on the ground
            if (collisionInfo.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                CanJump = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            //Player cannot jump midair
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                CanJump = false;
            }
        }

        private void CheckFallVelocity()
        {
            Debug.Log(fallVelocity);
            if (fallVelocity <= -27f)
            {
                PlayerManager.DamagePlayer(15);
            }
        }

        private void RegisterFallVelocity()
        {
            if (CanJump == false)
            {
                fallVelocity = body.velocity.y;
            }
        }
    }
}

