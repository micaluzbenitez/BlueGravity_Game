using BlueGravity.Inventory.ClothesInventory;
using UnityEngine;

namespace BlueGravity.Inventory
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
    public class Item : ScriptableObject
    {
        public enum ITEM_TYPE
        {
            Clothes,
            Tool,
            Material
        }

        public int id;
        public string itemName;
        public int value;
        public Sprite icon;

        [Space(80)] public ITEM_TYPE itemType;
        public Clothes clothes;
    }
}