using System;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    [Serializable]
    public struct BossEnemy
    {
        public GameObject enemyPrefab;
        [Tooltip("time in seconds after start level when script startted spawn enemys")]
        public float timeToStartSpawnEnemies;
        public Vector3 startedPosision;
    }
}
