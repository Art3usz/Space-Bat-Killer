using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game_Controls
{
    internal class PauseScript : MonoBehaviour
    {
        public bool isPaused;
        private MenuPanelScript MP;
        private void Start()
        {
            MP = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuPanelScript>();
        }
        public void PauseGame(bool isPause = false)
        {          

            if (isPause == isPaused || SceneManager.GetActiveScene().name.Equals("Menu"))
            {
                return;
            }

            isPaused = isPause;

            if (isPaused)
            {
                Time.timeScale = 0;
                MP.ShowHidePanel("pause");
            }
            else
            {
                Time.timeScale = 1;
                MP.ShowHidePanel("Hide All");
            }
        }

        private void Update()
        {
            if(SceneManager.GetActiveScene().name.Equals("Menu"))
            {
                Time.timeScale = 1;
                isPaused = false;

            }
            if (Input.GetKeyDown(GameManager.GM.pause) )
            {
                PauseGame(!isPaused);
            }
        }

    }
}
