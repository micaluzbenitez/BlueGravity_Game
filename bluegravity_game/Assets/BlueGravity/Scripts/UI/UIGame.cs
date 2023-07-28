using UnityEngine;
using BlueGravity.Inventory;
using BlueGravity.Managers;
using BlueGravity.Entities.Player;
using UnityEngine.UI;

namespace BlueGravity.UI
{
    public class UIGame : MonoBehaviour
    {
        [Header("Scenes")]
        [SerializeField] private string mainMenuSceneName;

        [Header("Tool")]
        [SerializeField] private Image currentToolIcon;

        [Header("Inventory")]
        [SerializeField] private GameObject inventory;

        private void Awake()
        {
            PlayerInventory.Instance.OnToolEquiped += UpdateCurrentTool;
        }

        private void OnDestroy()
        {
            PlayerInventory.Instance.OnToolEquiped -= UpdateCurrentTool;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) TurnOnInventory();
        }

        private void TurnOnInventory()
        {
            if (Time.timeScale == 0) return;

            inventory.SetActive(!inventory.activeSelf);

            if (inventory.activeSelf) PauseGame();
            else UnpauseGame();
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void UnpauseGame()
        {
            Time.timeScale = 1;
        }

        public void UpdateCurrentTool(Item tool)
        {
            if (tool != null && currentToolIcon != null)
            {
                currentToolIcon.gameObject.SetActive(true);
                currentToolIcon.sprite = tool.icon;
            }
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