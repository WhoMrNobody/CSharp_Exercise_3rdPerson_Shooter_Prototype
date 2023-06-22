using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Managers;
using UdemyProject3.ScritableObject;
using UnityEngine;

namespace UdemyProject3.Controller
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] SpawnInfoSO _spawnInfo;

        float _maxTime;
        float _currentTime;

        void Start()
        {
            _maxTime = _spawnInfo.RandomSpawnMaxTime;
        }

        void Update()
        {
            _currentTime += Time.deltaTime;

            if(_currentTime > _maxTime && EnemyManager.Instance.CanSpawn && !GameManager.Instance.IsWaveFinished)
            {
                Spawn();
            }
        }

        void Spawn()
        {
            EnemyController enemyController =  Instantiate(_spawnInfo.EnemyPrefab, transform.position, Quaternion.identity);
            EnemyManager.Instance.AddEnemyController(enemyController);

            _currentTime = 0f;
            _maxTime = _spawnInfo.RandomSpawnMaxTime;
        }
    }
}

