using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettingsScript : MonoBehaviour
{
    public Dropdown resolDropdown;
    public Text selResText;
    public Toggle fullScreenToggle;
    public Text qualityText;
    public static GraphicsSettingsScript GS;
    private int oldQualityLv;
    public Text acceptText;
    private bool acceptResolution;
    private int counter = 9;
    private string curRes;
    // Use this for initialization
    private void Start()
    {
        if (GS == null)
        {
            GS = this;
        }
        else if (GS != this)
        {
            Destroy(gameObject);
        }

        oldQualityLv = QualitySettings.GetQualityLevel();
        fullScreenToggle.isOn = Screen.fullScreen;
        SetQualityName();
        UpdateResList();
        SetCurValResolDrob();
    }

    private void UpdateResList()
    {
        resolDropdown.options.Clear();
        foreach (Resolution k in Screen.resolutions)
        {
            string[] j = k.ToString().Split(' ');
            if (int.Parse(j[0]) > 799)
            {
                resolDropdown.options.Add(new Dropdown.OptionData((j[0] + " x " + j[2]), null));
            }
        }


        SetCurValResolDrob();

    }


    public void BackToOrgRes()
    {
        acceptResolution = true;// Wartość false pozwala uruchomic timer służacy do autopowrotu do poprzedniej rożdzielczości 
        counter = 9;
        StartCoroutine(IEBackToOrgRes());
    }

    private IEnumerator IEBackToOrgRes()
    {
        string[] res = selResText.text.Split(' ');
        curRes = fullScreenToggle.isOn ? Screen.currentResolution.ToString().Split('@')[0] : (Screen.width + " x " + Screen.height + " ");
        Screen.SetResolution(int.Parse(res[0]), int.Parse(res[2]), fullScreenToggle.isOn);
        for (; counter > 0 && !acceptResolution; counter--)
        {
            acceptText.text = "Accept (" + counter + ")";
            yield return new WaitForSecondsRealtime(1);
        }
        if (!acceptResolution)
        {
            res = curRes.Split(' ');
            Screen.SetResolution(int.Parse(res[0]), int.Parse(res[2]), fullScreenToggle.isOn);
        }


        yield return new WaitForFixedUpdate();
        SetCurValResolDrob();
        UpdateResList();

    }

    public void ChangeFullScreenMode()
    {
        Screen.fullScreen = fullScreenToggle.isOn;
    }

    public void SetCurValResolDrob()
    {
      //  acceptText.text = "Accept";
        counter = 0;
        fullScreenToggle.isOn = Screen.fullScreen;
        selResText.text = fullScreenToggle.isOn ? Screen.currentResolution.ToString().Split('@')[0] : (Screen.width + " x " + Screen.height + " ");

        QualitySettings.SetQualityLevel(oldQualityLv);
        SetQualityName();

        for (int i = 0; i < resolDropdown.options.Count; i++)
        {
            if (selResText.text.Equals(resolDropdown.options[i].text))
            {
                resolDropdown.value = i;
                return;
            }
        }
    }

    public void ChangeResolution()
    {
      //  acceptText.text = "Accept";
        acceptResolution = true;
        counter = 0;
        string[] res = selResText.text.Split(' ');
        Screen.SetResolution(int.Parse(res[0]), int.Parse(res[2]), fullScreenToggle.isOn);
        oldQualityLv = QualitySettings.GetQualityLevel();
    }

    private void SetQualityName()
    {
        qualityText.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
    }

    public void ChangeQuality(bool quaLvChange)
    {

        if (quaLvChange)
        {
            QualitySettings.DecreaseLevel();
        }
        else
        {
            QualitySettings.IncreaseLevel();
        }
        SetQualityName();

    }
}
