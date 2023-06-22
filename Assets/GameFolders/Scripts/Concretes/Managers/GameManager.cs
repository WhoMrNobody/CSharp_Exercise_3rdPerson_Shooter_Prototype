using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject3.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] int _waveMaxCount = 20;
        public bool IsWaveFinished => _waveMaxCount <= 0;

        void Awake()
        {
            SetSingletonThisGameObject(this);
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
            if (IsWaveFinished) { return; }

            _waveMaxCount--;
        }
    }
}

