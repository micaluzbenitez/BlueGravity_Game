using UnityEngine;

namespace BlueGravity.Inventory
{
    public class ItemPick : MonoBehaviour
    {
        [Header("Item")]
        [SerializeField] private Item item;

        private void OnMouseDown()
        {
            PickUpItem();
        }

        private void PickUpItem()
        {
            InventoryManager.Instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}