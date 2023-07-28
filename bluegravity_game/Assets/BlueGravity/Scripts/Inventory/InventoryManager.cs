using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BlueGravity.Toolbox;

namespace BlueGravity.Inventory
{
    public class InventoryManager : MonoBehaviourSingleton<InventoryManager>
    {
        [Header("Coins")]
        [SerializeField] private TMP_Text coinsText;

        [Header("Inventory")]
        [SerializeField] private GameObject inventoryItemPrefab;
        [SerializeField] private Transform itemContent;
        [SerializeField] private Toggle enableRemove;

        [Header("Items")]
        [SerializeField] private List<Item> items = new List<Item>();

        private InventoryItemController[] inventoryItemControllers;

        public void OpenInventory()
        {
            // Clean inventory content
            foreach (Transform item in itemContent)
            {
                Destroy(item.gameObject);
            }

            // Load inventory content
            foreach (var item in items)
            {
                ListItem(item);
            }

            SetInventoryItems();
        }

        private void ListItem(Item item)
        {
            GameObject obj = Instantiate(inventoryItemPrefab, itemContent);

            var itemIcon = obj.transform.Find("Item Icon").GetComponent<Image>();
            var itemName = obj.transform.Find("Item Name").GetComponent<TMP_Text>();
            var itemValue = obj.transform.Find("Item Value").GetComponent<TMP_Text>();
            var removeButton = obj.transform.Find("Remove Button").GetComponent<Button>();

            itemIcon.sprite = item.icon;
            itemName.text = item.itemName;
            itemValue.text = "$" + item.value;
            removeButton.gameObject.SetActive(enableRemove.isOn);
        }

        private void SetInventoryItems()
        {
            inventoryItemControllers = itemContent.GetComponentsInChildren<InventoryItemController>();

            for (int i = 0; i < items.Count; i++)
            {
                inventoryItemControllers[i].AddItem(items[i]);
            }
        }

        public void AddItem(Item item)
        {
            items.Add(item);
            ListItem(item);
            SetInventoryItems();
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void UpdateCoinsUI(int value)
        {
            coinsText.text = "Coins: " + value;
        }

        public void EnableItemsRemove()
        {
            foreach (Transform item in itemContent)
            {
                item.Find("Remove Button").gameObject.SetActive(enableRemove.isOn);
            }
        }
    }
}