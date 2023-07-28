using UnityEngine;
using UnityEngine.UI;
using BlueGravity.Entities.Player;
using BlueGravity.Inventory.ClothesInventory;

namespace BlueGravity.Inventory
{
    public class InventoryItemController : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Button removeButton;

        private Item item;

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