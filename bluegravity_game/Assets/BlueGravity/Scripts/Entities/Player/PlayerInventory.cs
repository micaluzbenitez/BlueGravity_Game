using System;
using BlueGravity.Toolbox;
using BlueGravity.Inventory;
using BlueGravity.Inventory.ClothesInventory;
using UnityEngine;

namespace BlueGravity.Entities.Player
{
    public class PlayerInventory : MonoBehaviourSingleton<PlayerInventory>
    {
        // Clothes
        public GameObject currentOutClothes;// { get; private set; }
        public GameObject currentHarClothes;// { get; private set; }
        public GameObject currentHatClothes;// { get; private set; }

        private GameObject instantiateOutClothes;
        private GameObject instantiateHarClothes;
        private GameObject instantiateHatClothes;

        // Tool
        public Item currentTool { get; private set; }

        private PlayerMovement playerMovement;

        public Action<Item> OnToolEquiped;

        public override void Awake()
        {
            base.Awake();
            playerMovement = GetComponent<PlayerMovement>();
        }

        public void WearClothes(Item item)
        {
            switch (item.clothes.clothesType)
            {
                case Clothes.CLOTHES_TYPE.Out:
                    EquipClothes(item, currentOutClothes, instantiateOutClothes);
                    break;
                case Clothes.CLOTHES_TYPE.Har:
                    EquipClothes(item, currentHarClothes, instantiateHarClothes);
                    break;
                case Clothes.CLOTHES_TYPE.Hat:
                    EquipClothes(item, currentHatClothes, instantiateHatClothes);
                    break;
            }
        }

        public void EquipClothes(Item item, GameObject clothes, GameObject instantiateObj)
        {
            //if (clothes) clothes.GetComponent<ClothesController>().RemoveClothes();

            clothes = item.clothes.prefab;
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
    }
}