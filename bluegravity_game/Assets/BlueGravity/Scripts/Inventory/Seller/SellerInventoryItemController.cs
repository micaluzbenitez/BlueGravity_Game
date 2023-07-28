using BlueGravity.Entities.Player;
using BlueGravity.Entities.Seller;
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
            if (PlayerInventory.Instance.GetCoins() < item.value) return;

            PlayerInventory.Instance.Buy(item.value);
            SellerInventory.Instance.Sell(item.value);
            InventoryManager.Instance.AddItem(item);
            RemoveItem();
        }
    }
}