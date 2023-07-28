using BlueGravity.Entities.Player;
using UnityEngine;

namespace BlueGravity.Inventory.ClothesInventory
{
    public class ClothesController : MonoBehaviour
    {
        private Animator animator;
        private PlayerMovement playerMovement;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            if (animator && playerMovement)
            {
                if (playerMovement.GetMovementVector().magnitude > 0)
                {
                    animator.SetBool("IsMoving", true);

                    animator.SetFloat("Horizontal", playerMovement.GetMovementVector().x);
                    animator.SetFloat("Vertical", playerMovement.GetMovementVector().y);
                }
                else
                {
                    animator.SetBool("IsMoving", false);
                }
            }
        }

        public void SetPlayerMovement(PlayerMovement playerMovement)
        {
            this.playerMovement = playerMovement;
        }

        public void RemoveClothes()
        {
            gameObject.SetActive(false);
        }
    }
}