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

        float _currentTime = 0f;
        IAttackType _attackType;

        public AnimatorOverrideController AnimatorOverrideController => _attackType.AttackInfo.AnimOverrideController;

        void Awake()
        {
            _attackType = GetComponent<IAttackType>();
        }
        void Update()
        {
            _currentTime += Time.deltaTime;

            _canFire = _currentTime > _attackType.AttackInfo.AttackMaxDelay;

        }

        public void CanAttack()
        {
            if(!_canFire) { return;  }

            _attackType.AttackAction();

            _currentTime = 0f;
        }
    }
}

