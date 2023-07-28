using UnityEngine;
using BlueGravity.Toolbox;
using BlueGravity.Inventory;
using System;

namespace BlueGravity.Entities.Player
{
    public class PlayerInventory : MonoBehaviourSingleton<PlayerInventory>
    {
        public Item currentTool { get; private set; }

        public Action<Item> OnToolEquiped;

        public void WearClothes()
        {

        }

        public void EquipTool(Item tool)
        {
            currentTool = tool;
            OnToolEquiped?.Invoke(tool);
        }
    }
}