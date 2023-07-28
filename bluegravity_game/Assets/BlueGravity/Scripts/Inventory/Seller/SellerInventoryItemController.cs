using UnityEngine;

namespace BlueGravity.Inventory.Seller
{
    public class SellerInventoryItemController : MonoBehaviour
    {
        private Item item;

        public void AddItem(Item newItem)
        {
            item = newItem;
        }

        public void RemoveItem()
        {
            SellerInventoryManager.Instance.RemoveItem(item);
            Destroy(gameObject);
        }

        public void UseItem()
        {
            InventoryManager.Instance.AddItem(item);
            RemoveItem();
        }
    }
}