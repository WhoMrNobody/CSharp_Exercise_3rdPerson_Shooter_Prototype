using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3.ScritableObject
{
    [CreateAssetMenu(fileName ="Attack Info", menuName = "Create new Attack Info", order = 51)]
    public class AttackSO : ScriptableObject
    {
        [SerializeField] float _weaponRange = 1f;
        [SerializeField] float _attackMaxDelay = 2.5f;
        [SerializeField] int _damage = 10;
        [SerializeField] LayerMask _layerMask;
        

        public float WeaponRange => _weaponRange;
        public LayerMask LayerMask => _layerMask;
        public float AttackMaxDelay => _attackMaxDelay;
        public int Damage  => _damage;
    }
}

