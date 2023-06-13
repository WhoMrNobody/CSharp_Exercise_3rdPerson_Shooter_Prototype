using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Combats;
using UnityEngine;

namespace UdemyProject3.ScritableObject
{
    enum AttackTypeEnum : byte
    {
        Range, Melee
    }

    [CreateAssetMenu(fileName ="Attack Info", menuName = "Create new Attack Info", order = 51)]
    public class AttackSO : ScriptableObject
    {
        [SerializeField] AttackTypeEnum _attackType;
        [SerializeField] float _weaponRange = 1f;
        [SerializeField] float _attackMaxDelay = 2.5f;
        [SerializeField] int _damage = 10;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] AnimatorOverrideController _animOverrideController;

        public float WeaponRange => _weaponRange;
        public LayerMask LayerMask => _layerMask;
        public float AttackMaxDelay => _attackMaxDelay;
        public int Damage  => _damage;
        public AnimatorOverrideController AnimOverrideController => _animOverrideController;

        public IAttackType GetAttackType(Transform transform)
        {
            if(_attackType == AttackTypeEnum.Range)
            {
                return new RangeAttackType(transform, this);
            }
            else
            {
                return new MeleeAttackType(transform, this);
            }
        }
    }
}

