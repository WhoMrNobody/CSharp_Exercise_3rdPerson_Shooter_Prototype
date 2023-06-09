using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Combat;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Combats;
using UdemyProject3.ScritableObject;
using UnityEngine;

namespace UdemyProject3.Controller
{
    public class WeaponController : MonoBehaviour
    {
        
        [SerializeField] bool _canFire;
        [SerializeField] Transform _transformObject;
        [SerializeField] AttackSO _attackSO;

        float _currentTime = 0f;
        IAttackType _attackType;

        void Awake()
        {
            _attackType = _attackSO.GetAttackType(_transformObject);
        }
        void Update()
        {
            _currentTime += Time.deltaTime;

            _canFire = _currentTime > _attackSO.AttackMaxDelay;

        }

        public void CanAttack()
        {
            if(!_canFire) { return;  }

            _attackType.AttackAction();

            _currentTime = 0f;
        }
    }
}

