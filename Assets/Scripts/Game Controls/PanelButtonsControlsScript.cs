using UnityEngine;
public class PanelButtonsControlsScript : MonoBehaviour
{
    public GameObject[] panels;
    // Use this for initialization
    private void Start()
    {
        SwitchToPanel(0);
    }

    public void SwitchToPanel(int nr)
    {
        for (int k = 0; k < panels.Length; k++)
        {
            panels[k].SetActive(false);
        }



        if (nr > -1 && nr < panels.Length)
        {
            panels[nr].SetActive(true);
        }
    }
}
