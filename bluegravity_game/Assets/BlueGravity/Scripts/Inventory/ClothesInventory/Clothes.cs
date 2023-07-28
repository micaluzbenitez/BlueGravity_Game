using UnityEngine;

namespace BlueGravity.Inventory.ClothesInventory
{
    [CreateAssetMenu(fileName = "New Clothes", menuName = "Item/Create New Clothes")]
    public class Clothes : ScriptableObject
    {
        public enum CLOTHES_TYPE
        {
            Out,
            Har,
            Hat
        }

        public CLOTHES_TYPE clothesType;
        public GameObject prefab;
    }
}