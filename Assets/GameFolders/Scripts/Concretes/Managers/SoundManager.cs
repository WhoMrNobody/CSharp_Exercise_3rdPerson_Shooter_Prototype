using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Helpers;
using UdemyProject3.Controller;
using UnityEngine;

namespace UdemyProject3.Managers
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        [SerializeField] AudioClip[] _audioClips;
        SoundController[] _soundControllers;
        void Awake()
        {
            SetSingletonThisGameObject(this);
            _soundControllers = GetComponentsInChildren<SoundController>();
        }

        void Start()
        {
            for (int i = 0; i < _soundControllers.Length; i++)
            {
                _soundControllers[i].SetClip(_audioClips[i]);
            }

            _soundControllers[0].PlaySound(Vector3.zero);
        }

        public void PlayFireSound(Vector3 soundPlayLocation)
        {
            _soundControllers[1].PlaySound(soundPlayLocation);
        }
    }

}
