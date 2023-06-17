using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Controller;
using UnityEngine;

namespace UdemyProject3.ScritableObject
{
    [CreateAssetMenu(fileName = "SpawnInfo", menuName = "Combat/Spawner Info/Create New")]

    public class SpawnInfoSO : ScriptableObject
    {
        [SerializeField] EnemyController _enemyPrefab;
        [SerializeField] float _maxSpawnTime = 15f;
        [SerializeField] float _minSpawnTime = 2f;

        public EnemyController EnemyPrefab => _enemyPrefab;
        public float RandomSpawnMaxTime => Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}


