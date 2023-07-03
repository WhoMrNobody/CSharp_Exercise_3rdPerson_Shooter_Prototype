using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Combat;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Managers;
using UdemyProject3.ScritableObject;
using UnityEngine;

namespace UdemyProject3.Combats
{
    public class RangeAttackType : IAttackType
    {
        AttackSO _attackSO;

        Camera _mainCamera;
      
        public RangeAttackType(Transform transformObject, AttackSO attackSO)
        {
            _mainCamera = transformObject.GetComponent<Camera>();
            _attackSO = attackSO;
        }
        public void AttackAction()
        {
            Ray ray = _mainCamera.ViewportPointToRay(Vector3.one / 2);

            if(Physics.Raycast(ray, out RaycastHit _hit, _attackSO.WeaponRange, _attackSO.LayerMask))
            {

                if(_hit.collider.TryGetComponent(out IHealth _iHealth))
                {
                    _iHealth.TakeDamage(_attackSO.Damage);
                }
            }

            SoundManager.Instance.PlayFireSound(_mainCamera.transform.position);
        }

    }

}
