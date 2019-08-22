using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatsController : MonoBehaviour
{
    public static PlayerStatsController PSC;

    [Range(0, 10)]
    public int numberOfLives = 3;
    [Range(0, 10)]
    public int nrOfCurrentWeapon = 0;

    public uint score = 0;

    public int immortalityLenght = 2;
    public bool immortality = false;

    // Start is called before the first frame update
    private void Start()
    {
        if (PSC == null)
        {
            DontDestroyOnLoad(gameObject);
            PSC = this;
        }
        else if (PSC != this)
        {
            Destroy(gameObject);
        }
    }

    public void modifiedLife(int nrModifyLife = 0)
    {
        numberOfLives += nrModifyLife;
        if (numberOfLives <= 0)
        {
             death();
        }
     else   if (numberOfLives >=1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       else if (numberOfLives > 10)
        {
            numberOfLives = 10;
        }
    }

    private void death()
    {
        addToHighScore();
        resetStats();
        MenuPanelScript.MP.ShowHidePanel();
    }


    public void resetStats()
    {
        addToHighScore();
        score = 0;
        immortality = false;
        numberOfLives = 3;
        nrOfCurrentWeapon = 0;
    }

    private void addToHighScore()
    {

    }

    private IEnumerator ImortalityControler()
    {

        int immortal = immortalityLenght;
        while (immortal > 0)
        {
            immortality = true;
            yield return new WaitForSecondsRealtime(1f);

            immortal--;

        }
        immortality = false;
    }
}
