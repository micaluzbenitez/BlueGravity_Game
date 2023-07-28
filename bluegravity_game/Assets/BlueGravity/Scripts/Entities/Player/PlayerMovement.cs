using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravity.Entities.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float speed = 0;

        private Rigidbody2D playerRigidbody = null;
        private Animator animator = null;
        private Vector3 movementVector = Vector3.zero;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Movement();
            UpdateAnimation();
        }

        private void Movement()
        {
            if (movementVector.y == 0) movementVector.x = Input.GetAxis("Horizontal");
            if (movementVector.x == 0) movementVector.y = Input.GetAxis("Vertical");

            playerRigidbody.velocity = movementVector.normalized * speed;
        }

        private void UpdateAnimation()
        {
            if (animator != null)
            {
                if (movementVector.magnitude > 0)
                {
                    animator.SetBool("IsMoving", true);

                    animator.SetFloat("Horizontal", movementVector.x);
                    animator.SetFloat("Vertical", movementVector.y);
                }
                else
                {
                    animator.SetBool("IsMoving", false);
                }
            }
        }
    }
}