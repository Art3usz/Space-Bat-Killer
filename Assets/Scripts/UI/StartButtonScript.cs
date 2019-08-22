using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    MenuPanelScript MP;
    private void Start()
    {
        MP = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuPanelScript>();
    }
    public void StartGame(){
        MP.ShowHidePanel("Hide All");
        SceneManager.LoadSceneAsync("lv 1");
    }
}
