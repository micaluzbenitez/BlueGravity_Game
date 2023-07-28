using System;
using BlueGravity.Toolbox;
using BlueGravity.Inventory;
using BlueGravity.Inventory.ClothesInventory;

namespace BlueGravity.Entities.Player
{
    public class PlayerInventory : MonoBehaviourSingleton<PlayerInventory>
    {
        // Clothes
        public Clothes currentOutClothes;// { get; private set; }
        public Clothes currentHarClothes;// { get; private set; }
        public Clothes currentHatClothes;// { get; private set; }

        // Tool
        public Item currentTool { get; private set; }

        public Action<Item> OnToolEquiped;

        public void WearClothes(Item item)
        {
            switch (item.clothes.clothesType)
            {
                case Clothes.CLOTHES_TYPE.Out:
                    currentOutClothes = item.clothes;
                    break;
                case Clothes.CLOTHES_TYPE.Har:
                    currentHarClothes = item.clothes;
                    break;
                case Clothes.CLOTHES_TYPE.Hat:
                    currentHatClothes = item.clothes;
                    break;
            }
        }

        public void EquipTool(Item tool)
        {
            currentTool = tool;
            OnToolEquiped?.Invoke(tool);
        }
    }
}