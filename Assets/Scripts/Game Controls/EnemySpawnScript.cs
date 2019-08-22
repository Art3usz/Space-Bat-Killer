using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{


    public List<BasicEnemy> minions = new List<BasicEnemy>();
    public List<BossEnemy> bosses = new List<BossEnemy>();
    public Transform downBorder, UpBorder;
    // Start is called before the first frame update
    private void Start()
    {
        foreach (BasicEnemy e in minions)
        {
            StartCoroutine(SpawnBasic(e));
        }

        foreach (BossEnemy b in bosses)
        {
            StartCoroutine(SpawnBosses(b));
        }
    }

    private IEnumerator SpawnBasic(BasicEnemy enemy)
    {
        yield return new WaitForSecondsRealtime(enemy.timeToStartSpawnEnemies);
        while (enemy.numberEnemies > 0 || enemy.infinityNumberEnemies)
        {
            Destroy(Instantiate(enemy.enemyPrefab, new Vector3(10, Random.Range(downBorder.position.y + 0.5f, UpBorder.position.y - 0.5f)), transform.rotation), 20f);
            yield return new WaitForSecondsRealtime(enemy.spawnFrequency);

        }
    }

    private IEnumerator SpawnBosses(BossEnemy enemy)
    {
        yield return new WaitForSecondsRealtime(enemy.timeToStartSpawnEnemies);
        Instantiate(enemy.enemyPrefab, enemy.startedPosision, transform.rotation);

    }
}

