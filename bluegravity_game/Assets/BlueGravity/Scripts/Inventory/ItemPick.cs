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

        private void Update()
        {
            if (collidingPlayer && Input.GetKeyDown(KeyCode.E)) CheckPickUp();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidingPlayer = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidingPlayer = false;
        }

        private void CheckPickUp()
        {
            if (toolToPickUp)
            {
                if (PlayerInventory.Instance.currentTool == toolToPickUp) PickUpItem();
            }
            else
            {
                PickUpItem();
            }
        }

        private void PickUpItem()
        {            
            InventoryManager.Instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}