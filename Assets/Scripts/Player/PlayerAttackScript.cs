using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public List<Projectile> projectiles;
    public PlayerAttackScript PA;

    private bool canShoot = true;

    private int selectedWeapon = 0;

    private void Start()
    {
        if (PA == null)
        {
            PA = this;
        }
        else
        {
            Destroy(gameObject);
        }

        selectedWeapon = PlayerStatsController.PSC.nrOfCurrentWeapon;
        selectedWeapon = selectedWeapon > projectiles.Count - 1 ? projectiles.Count - 1 : selectedWeapon;
    }

    public void SwitchWeapon(int nrSelectedWeapon)
    {
        if (nrSelectedWeapon < 0 || nrSelectedWeapon >= projectiles.Count) return;
        selectedWeapon = nrSelectedWeapon;
    }

    private void Update()
    {
        if (Input.GetKeyDown(GameManager.GM.attack) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot(int nrOfProjectile = 0)
    {
        canShoot = false;
        while (Input.GetKey(GameManager.GM.attack))
        {
            Destroy(Instantiate(projectiles[selectedWeapon].projectilePrefab, transform), 10f);
            yield return new WaitForSecondsRealtime(60f / projectiles[selectedWeapon].rPM);
        }
        canShoot = true;
        yield return null;
    }
    private void nextLevel()
    {
        PlayerStatsController.PSC.nrOfCurrentWeapon = selectedWeapon;
    }
}
