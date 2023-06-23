using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Helpers;
using UdemyProject3.Controller;
using UnityEngine;

namespace UdemyProject3.Managers
{
    public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
    {
        [SerializeField] int _maxCountGameOn = 20;
        [SerializeField] List<EnemyController> _enemies;

        public List<Transform> Targets { get; private set; }
        public bool CanSpawn => _maxCountGameOn > _enemies.Count;
        public bool IsEnemyListEmpty => _enemies.Count <= 0;
        private void Awake()
        {
            SetSingletonThisGameObject(this);
            _enemies = new List<EnemyController>();
            Targets = new List<Transform>();
        }

        public void AddEnemyController(EnemyController enemyController)
        {
            enemyController.transform.parent = this.transform;
            _enemies.Add(enemyController);
        }

        public void RemoveEnemyController(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
            GameManager.Instance.DecreaseWaveCount();
        }
    }

}
