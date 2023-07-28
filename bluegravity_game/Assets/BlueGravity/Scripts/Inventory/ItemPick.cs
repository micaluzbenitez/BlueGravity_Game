using UnityEngine;

namespace BlueGravity.Inventory
{
    public class ItemPick : MonoBehaviour
    {
        [Header("Item")]
        [SerializeField] private Item item;

        private bool collidingPlayer = false;

        private void Update()
        {
            if (collidingPlayer && Input.GetKeyDown(KeyCode.E)) PickUpItem();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidingPlayer = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidingPlayer = false;
        }

        private void PickUpItem()
        {
            InventoryManager.Instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}