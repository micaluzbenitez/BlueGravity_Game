using UnityEngine;

namespace BlueGravity.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject[] panels;

        private bool pause = false;

        private void Update()
        {
            PauseState();
        }

        private void PauseState()
        {
            pause = false;

            for (int i = 0; i < panels.Length; i++)
            {
                if (panels[i].activeSelf) pause = true;
            }

            if (pause) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
    }
}