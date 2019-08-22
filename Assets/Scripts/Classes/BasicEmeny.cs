using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    [Serializable]
   public struct BasicEnemy
    {
        public GameObject enemyPrefab;
        public int numberEnemies;
        [Tooltip("time in seconds after start level when script startted spawn enemys")]
        public float timeToStartSpawnEnemies;
        public bool infinityNumberEnemies;
        public int valueOfPoints;
        public float spawnFrequency;
    }
}
