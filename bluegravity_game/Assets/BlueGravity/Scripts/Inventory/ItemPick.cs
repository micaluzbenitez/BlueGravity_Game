using BlueGravity.Entities.Player;
using UnityEngine;

namespace BlueGravity.Inventory
{
    public class ItemPick : MonoBehaviour
    {
        [Header("Item")]
        [SerializeField] private Item item;

        [Header("Tool")]
        [SerializeField, Tooltip("Leave empty if it don't need")] private Item toolToPickUp;

        private bool collidingPlayer = false;
        private bool pickable;

        private void Update()
        {
            if (collidingPlayer && Input.GetKeyDown(KeyCode.E)) PickUpItem();
        }

        #region Player_Detection
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidingPlayer = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidingPlayer = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidingPlayer = false;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidingPlayer = false;
        }
        #endregion

        private void PickUpItem()
        {
            if (!pickable) return;

            InventoryManager.Instance.AddItem(item);
            Destroy(gameObject);
        }

        public bool CheckPickUp()
        {
            if (toolToPickUp)
            {
                if (PlayerInventory.Instance.currentTool == toolToPickUp) pickable = true;
                else pickable = false;
            }
            else
            {
                pickable = true;
            }

            return pickable;
        }
    }
}