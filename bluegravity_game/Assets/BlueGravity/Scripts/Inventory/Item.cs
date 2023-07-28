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
        public ITEM_TYPE itemType;
        public Sprite icon;
    }
}