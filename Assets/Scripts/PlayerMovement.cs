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
        [SerializeField, Range(0, 100)] private float movementSpeed;
        // [SerializeField] private CharacterController _characterController;
        private float turnSmoothTime = 0.1f;
        private float turnSmoothVelocity;
        private Rigidbody body;
        private Vector3 velocity;
        private KeyCode jumpKey = KeyCode.Space;

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
                // _characterController.Move(Time.deltaTime * movementSpeed * moveDir.normalized);
                body.velocity += velocity*Time.deltaTime;
            }
            
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        void JumpPlayer()
        {
            Debug.Log("[PlayerMovement] Jump");
            body.velocity += movementSpeed*(Vector3.up/2);
        }
    }
}

