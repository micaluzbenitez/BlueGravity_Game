using UnityEngine;
using BlueGravity.Managers;

namespace BlueGravity.UI
{
    public class UICredits : MonoBehaviour
    {
        [Header("Scenes")]
        [SerializeField] private string mainMenuSceneName;

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