using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Combat;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Controller;
using UdemyProject3.Managers;
using UdemyProject3.ScritableObject;
using UnityEngine;

namespace UdemyProject3.Combats
{
    public class RangeAttackType : MonoBehaviour, IAttackType
    {
        [SerializeField] AttackSO _attackSO;
        [SerializeField] Transform _bulletPoint;
        [SerializeField] BulletFXController _bulletFXController;
        [SerializeField] Camera _mainCamera;

        public AttackSO AttackInfo => _attackSO;

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

            var bullet = Instantiate(_bulletFXController, _bulletPoint.position, _bulletPoint.rotation);
            bullet.SetDirection(ray.direction);

            SoundManager.Instance.RangeAttackSound(_attackSO.AudioClip,_mainCamera.transform.position);
        }

    }

}
