using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Abstract.States;
using UdemyProject3.Animations;
using UnityEngine;

namespace UdemyProject3.States.EnemyStates
{
    public class AttackState : IState
    {   
        IEnemyController _enemyController;

        public AttackState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            
        }

        public void OnExit()
        {
            _enemyController.CharacterAnimation.AttackAnimation(false);
        }

        public void Tick()
        {
            _enemyController.transform.LookAt(_enemyController.Target);
            _enemyController.transform.eulerAngles = new Vector3(0f, _enemyController.transform.eulerAngles.y, 0f);
 
        }

        public void TickFixed()
        {
            _enemyController.InventoryController.CurrentWeapon.CanAttack();
        }

        public void TickLate()
        {
            _enemyController.CharacterAnimation.AttackAnimation(true);
        }
    }

}
