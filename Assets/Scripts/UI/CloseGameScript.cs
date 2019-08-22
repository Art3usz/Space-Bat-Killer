using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGameScript : MonoBehaviour
{
    public void EndGame()
    {
        Application.Quit();
    }

    public void EndLevel()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
