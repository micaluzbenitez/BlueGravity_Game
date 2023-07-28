using System;
using BlueGravity.Toolbox;
using BlueGravity.Inventory;
using BlueGravity.Inventory.ClothesInventory;
using UnityEngine;
using BlueGravity.Inventory.Seller;

namespace BlueGravity.Entities.Player
{
    public class PlayerInventory : MonoBehaviourSingleton<PlayerInventory>
    {
        [Header("Coins")]
        [SerializeField] private int coins;

        // Clothes
        public GameObject currentOutClothes { get; private set; }
        public GameObject currentHarClothes { get; private set; }
        public GameObject currentHatClothes { get; private set; }

        // Tool
        public Item currentTool { get; private set; }

        private PlayerMovement playerMovement;

        public Action<Item> OnToolEquiped;

        public override void Awake()
        {
            base.Awake();
            playerMovement = GetComponent<PlayerMovement>();
        }

        public void OpenInventory()
        {
            InventoryManager.Instance.UpdateCoinsUI(this.coins);
            InventoryManager.Instance.OpenInventory();
        }

        public void WearClothes(Item item)
        {
            switch (item.clothes.clothesType)
            {
                case Clothes.CLOTHES_TYPE.Out:
                    currentOutClothes = item.clothes.prefab;
                    EquipClothes(currentOutClothes);
                    break;
                case Clothes.CLOTHES_TYPE.Har:
                    currentHarClothes = item.clothes.prefab;
                    EquipClothes(currentHarClothes);
                    break;
                case Clothes.CLOTHES_TYPE.Hat:
                    currentHatClothes = item.clothes.prefab;
                    EquipClothes(currentHatClothes);
                    break;
            }
        }

        public void EquipClothes(GameObject clothes)
        {
            //if (clothes) clothes.GetComponent<ClothesController>().RemoveClothes();

            GameObject obj = Instantiate(clothes);
            obj.transform.SetParent(transform);
            obj.transform.localPosition = Vector2.zero;

            ClothesController clothesController = obj.GetComponent<ClothesController>();
            clothesController.SetPlayerMovement(playerMovement);
        }

        public void EquipTool(Item tool)
        {
            currentTool = tool;
            OnToolEquiped?.Invoke(tool);
        }

        public int GetCoins()
        {
            return coins;
        }

        public void Sell(int coins)
        {
            this.coins += coins;
            InventoryManager.Instance.UpdateCoinsUI(this.coins);
        }

        public void Buy(int coins)
        {

            this.coins -= coins;
            InventoryManager.Instance.UpdateCoinsUI(this.coins);
        }
    }
}