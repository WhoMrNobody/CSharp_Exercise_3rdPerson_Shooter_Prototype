using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject3.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] float _nextWaveBeginnerSecond = 10f;
        [SerializeField] float _waveMultiple = 1.5f;
        [SerializeField] int _maxWaveCount = 30;
        public bool IsWaveFinished => _currentWaveCount <= 0;

        int _currentWaveCount;

        void Awake()
        {
            SetSingletonThisGameObject(this);
        }

        private void Start()
        {
            _currentWaveCount = _maxWaveCount;
        }
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        IEnumerator LoadSceneAsync(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        public void DecreaseWaveCount()
        {   
            if (IsWaveFinished) {

                if (EnemyManager.Instance.IsEnemyListEmpty)
                {
                    StartCoroutine(BeginNextWaveAsync());
                }
            }
            else
            {
                _currentWaveCount--;
            }
        }

        IEnumerator BeginNextWaveAsync()
        {
            yield return new WaitForSeconds(_nextWaveBeginnerSecond);
            _maxWaveCount = System.Convert.ToInt32(_maxWaveCount * _waveMultiple);
            _currentWaveCount = _maxWaveCount;
        }
    }
}

