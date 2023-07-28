using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BlueGravity.Toolbox;
using static UnityEditor.Progress;

namespace BlueGravity.Inventory
{
    public class InventoryManager : MonoBehaviourSingleton<InventoryManager>
    {
        [Header("Inventory")]
        [SerializeField] private GameObject inventoryItemPrefab;
        [SerializeField] private Transform itemContent;
        [SerializeField] private Toggle enableRemove;

        [Header("Items")]
        [SerializeField] private List<Item> items = new List<Item>();

        private InventoryItemController[] inventoryItemControllers;

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void EnableItemsRemove()
        {
            foreach (Transform item in itemContent)
            {
                item.Find("Remove Button").gameObject.SetActive(enableRemove.isOn);
            }
        }

        public void ListItems()
        {
            // Clean inventory content
            foreach (Transform item in itemContent)
            {
                Destroy(item.gameObject);
            }

            // Load inventory content
            foreach (var item in items)
            {
                GameObject obj = Instantiate(inventoryItemPrefab, itemContent);

                var itemName = obj.transform.Find("Item Name").GetComponent<TMP_Text>();
                var itemIcon = obj.transform.Find("Item Icon").GetComponent<Image>();
                var removeButton = obj.transform.Find("Remove Button").GetComponent<Button>();

                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
                removeButton.gameObject.SetActive(enableRemove.isOn);
            }

            SetInventoryItems();
        }

        public void SetInventoryItems()
        {
            inventoryItemControllers = itemContent.GetComponentsInChildren<InventoryItemController>();

            for (int i = 0; i < items.Count; i++)
            {
                inventoryItemControllers[i].AddItem(items[i]);
            }
        }
    }
}