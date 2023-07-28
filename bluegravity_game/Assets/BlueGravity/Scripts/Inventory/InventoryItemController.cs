using UnityEngine;
using UnityEngine.UI;
using BlueGravity.Entities.Player;
using BlueGravity.Entities.Seller;
using BlueGravity.Inventory.Seller;

namespace BlueGravity.Inventory
{
    public class InventoryItemController : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Button removeButton;

        [SerializeField] private Item item;

        public void AddItem(Item newItem)
        {
            item = newItem;
        }

        public void RemoveItem()
        {
            InventoryManager.Instance.RemoveItem(item);
            Destroy(gameObject);
        }

        public void UseItem()
        {
            if (SellerInventory.Instance.openInventory)
            {
                if (SellerInventory.Instance.GetCoins() < item.value) return;

                PlayerInventory.Instance.Sell(item.value);
                SellerInventory.Instance.Buy(item.value);
                SellerInventoryManager.Instance.AddItem(item);
                RemoveItem();
            }
            else
            {
                switch (item.itemType)
                {
                    case Item.ITEM_TYPE.Clothes:
                        PlayerInventory.Instance.WearClothes(item);
                        break;

                    case Item.ITEM_TYPE.Tool:
                        PlayerInventory.Instance.EquipTool(item);
                        break;

                    case Item.ITEM_TYPE.Material:
                        break;
                }
            }
        }
    }
}