using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Helpers;
using UdemyProject3.Controller;
using UnityEngine;

namespace UdemyProject3.Managers
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        [SerializeField] AudioClip _audioClip;
        SoundController[] _soundControllers;

        public SoundController[] SoundControllers => _soundControllers;
        void Awake()
        {
            SetSingletonThisGameObject(this);
            _soundControllers = GetComponentsInChildren<SoundController>();
        }

        void Start()
        {
            _soundControllers[0].SetClip(_audioClip);
            _soundControllers[0].PlaySound(Vector3.zero);
        }

        public void RangeAttackSound(Vector3 soundPlayLocation)
        {
            _soundControllers[1].PlaySound(soundPlayLocation);
        }

        public void MeleeAttackSound(Vector3 soundPlayLocation)
        {
            _soundControllers[2].PlaySound(soundPlayLocation);
        }
    }

}
