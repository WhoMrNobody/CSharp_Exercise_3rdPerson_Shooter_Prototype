using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Combats;
using UnityEngine;

namespace UdemyProject3.ScritableObject
{

    [CreateAssetMenu(fileName ="Attack Info", menuName = "Combat/Attack Info/Create New", order = 51)]
    public class AttackSO : ScriptableObject
    {
        [SerializeField] float _weaponRange = 1f;
        [SerializeField] float _attackMaxDelay = 2.5f;
        [SerializeField] int _damage = 10;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] AnimatorOverrideController _animOverrideController;
        [SerializeField] AudioClip _audioClip;

        public float WeaponRange => _weaponRange;
        public LayerMask LayerMask => _layerMask;
        public float AttackMaxDelay => _attackMaxDelay;
        public int Damage  => _damage;
        public AnimatorOverrideController AnimOverrideController => _animOverrideController;
        public AudioClip AudioClip => _audioClip;

    }
}

