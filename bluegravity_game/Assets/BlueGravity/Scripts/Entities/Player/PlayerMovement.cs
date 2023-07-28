using Unity.VisualScripting;
using UnityEngine;

namespace BlueGravity.Entities.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float speed;

        [Header("Select field")]
        [SerializeField] private GameObject selectField;
        [SerializeField] private float distancePerPlayer;

        private Rigidbody2D playerRigidbody;
        private Animator animator;
        private Vector3 movementVector;

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

            PosicionSelectField();
        }

        private void PosicionSelectField()
        {
            Vector2 direction = movementVector.normalized;
            Vector2 newPosition = (Vector2)transform.position + (direction * distancePerPlayer);

            selectField.transform.position = newPosition;

            // Turn off if the player is idle
            if (movementVector.y == 0 && movementVector.x == 0) selectField.gameObject.SetActive(false);
            else selectField.gameObject.SetActive(true);
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