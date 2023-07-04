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

        public void RangeAttackSound(AudioClip audioClip,Vector3 soundPlayLocation)
        {
            _soundControllers[1].PlaySound(soundPlayLocation);
            _soundControllers[1].SetClip(audioClip);
        }

        public void MeleeAttackSound(AudioClip audioClip,Vector3 soundPlayLocation)
        {
            for (int i = 2; i < _soundControllers.Length; i++)
            {
                if (_soundControllers[i].IsPlaying) continue;

                _soundControllers[i].SetClip(audioClip);
                _soundControllers[i].PlaySound(soundPlayLocation);
                break;
            }
        }
    }

}
