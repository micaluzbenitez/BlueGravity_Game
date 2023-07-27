using UnityEngine.SceneManagement;
using BlueGravity.Toolbox;

namespace BlueGravity.Managers
{
    public class LoaderManager : MonoBehaviourSingleton<LoaderManager>
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}