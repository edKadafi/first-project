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
        [SerializeField, Range(0, 10)] private float movementSpeed;

        [SerializeField] private CharacterController _characterController;

        private float turnSmoothTime = 0.1f;

        private float turnSmoothVelocity;
        
        void Start()
        {
            var playerTransformRotation = PlayerTransform.rotation;
            playerTransformRotation.y = CameraOrient.rotation.y;
            PlayerTransform.rotation = playerTransformRotation;
        }
        
        void Update()
        {
            MovePlayer();
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
                _characterController.Move(Time.deltaTime * movementSpeed * moveDir.normalized);
            }
            
        }
    }
}

