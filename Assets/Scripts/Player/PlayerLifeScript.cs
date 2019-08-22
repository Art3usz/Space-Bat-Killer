using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeScript : MonoBehaviour
{
    public GameObject placeOfLives, LivePrefab;
    public Text textScore;
    private List<GameObject> lives = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < PlayerStatsController.PSC.numberOfLives; i++)
        {
            AddLiveInGame();
        }
    }

    private void Update()
    {
        textScore.text = "Score : "+ PlayerStatsController.PSC.score;
    }

    private void AddLiveInGame()
    {
        GameObject gm = Instantiate(LivePrefab, placeOfLives.transform);
        gm.transform.SetParent(placeOfLives.transform, false);
        lives.Add(gm);
    }

    private void loseLive()
    {
        Destroy(lives[0]);
        lives.RemoveAt(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                {
                    if (!PlayerStatsController.PSC.immortality)
                    {
                        loseLive();
                        PlayerStatsController.PSC.modifiedLife(-1);
                    }
                    break;
                }
            case "Nietoperek":
                {
                    if (!PlayerStatsController.PSC.immortality)
                    {
                        loseLive();
                        PlayerStatsController.PSC.modifiedLife(-1);
                    }
                    break;
                }
            case "BonusLive1":
                {
                    AddLiveInGame();
                    PlayerStatsController.PSC.modifiedLife(1);
                    break;
                }
            case "Bullet":
                {
                    break;
                }
            default:
                {
                    return;
                }
        }
    }
}
