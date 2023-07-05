using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Combat;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Managers;
using UdemyProject3.ScritableObject;
using UnityEngine;

namespace UdemyProject3.Combats
{
    public class MeleeAttackType : MonoBehaviour, IAttackType
    {
        [SerializeField] Transform _transformObject;
        [SerializeField] AttackSO _attackSO;

        public AttackSO AttackInfo => _attackSO;

        public void AttackAction()
        {
            Vector3 attackPoint = _transformObject.position;
            Collider[] colliders = Physics.OverlapSphere(attackPoint, _attackSO.WeaponRange, _attackSO.LayerMask);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out IHealth iHealth))
                {
                    iHealth.TakeDamage(_attackSO.Damage);
                }
            }

            SoundManager.Instance.MeleeAttackSound(_attackSO.AudioClip, _transformObject.position);
        }

    }
}

