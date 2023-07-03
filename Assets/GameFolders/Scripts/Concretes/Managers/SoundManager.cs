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
            _soundControllers[0].SetClip(_audioClips[0]);
            _soundControllers[1].SetClip(_audioClips[1]);

            _soundControllers[0].PlaySound();
        }

        public void PlayFireSound(Vector3 soundPlayLocation)
        {
            _soundControllers[1].SetClip(_audioClips[1]);
        }
    }

}
