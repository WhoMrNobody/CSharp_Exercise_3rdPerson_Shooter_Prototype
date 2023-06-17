using System.Collections;
using System.Collections.Generic;
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

            if(_currentTime > _maxTime)
            {
                Spawn();
            }
        }

        void Spawn()
        {
            Instantiate(_spawnInfo.EnemyPrefab, transform.position, Quaternion.identity);

            _currentTime = 0f;
            _maxTime = _spawnInfo.RandomSpawnMaxTime;
        }
    }
}

