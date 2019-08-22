using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanelScript : MonoBehaviour
{
    public GameObject mainMenu, pauseMenu, creditsPanel, settingsCanvas;
    public static MenuPanelScript MP;

    private void Start()
    {

        ShowHidePanel();
        SceneManager.LoadSceneAsync("Menu");
        if (MP == null)
        {
            MP = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowHidePanel(string panelToShow = "menu")
    {
        HideAll();
        switch (panelToShow)
        {
            case "menu":
                {
                    mainMenu.SetActive(true);
                    if (!SceneManager.GetActiveScene().name.Equals("Menu"))
                    {
                        if (SceneManager.GetActiveScene().buildIndex > 1)
                        {
                            PlayerStatsController.PSC.resetStats();
                        }

                        SceneManager.LoadScene("Menu");
                    }
                    break;
                }
            case "pause":
                {
                    pauseMenu.SetActive(true);
                    break;
                }
            case "credits":
                {
                    creditsPanel.SetActive(true);
                    break;
                }
            case "settings":
                {
                    settingsCanvas.SetActive(true);
                    break;
                }

        }
    }

    private void HideAll()
    {
        if (mainMenu != null && mainMenu.activeSelf)
        {
            mainMenu.SetActive(false);
        }
        if (pauseMenu != null && pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
        }
        if (creditsPanel != null && creditsPanel.activeSelf)
        {
            creditsPanel.SetActive(false);
        }
        if (settingsCanvas != null && settingsCanvas.activeSelf)
        {
            settingsCanvas.SetActive(false);
        }
    }
}
