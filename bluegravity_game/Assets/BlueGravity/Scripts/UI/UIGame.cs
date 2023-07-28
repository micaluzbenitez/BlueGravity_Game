using BlueGravity.Inventory;
using BlueGravity.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravity.UI
{
    public class UIGame : MonoBehaviour
    {
        [Header("Scenes")]
        [SerializeField] private string mainMenuSceneName;

        [Header("Inventory")]
        [SerializeField] private GameObject inventory;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) TurnOnInventory();
        }

        private void TurnOnInventory()
        {
            inventory.SetActive(!inventory.activeSelf);
            InventoryManager.Instance.ListItems();
        }

        public void LoadMainMenuScene()
        {
            LoaderManager.Get().LoadScene(mainMenuSceneName);
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}