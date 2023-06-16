using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Abstract.States;
using UnityEngine;
using UnityEngine.AI;

namespace UdemyProject3.States.EnemyStates
{
    public class DeadState : IState
    {
        IEnemyController _enemyController;
        float _maxTime = 5f, _currentTime = 0f;

        public DeadState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            _enemyController.Dead.DeadAction();
            _enemyController.CharacterAnimation.DeadAnimation("isDying");
            _enemyController.transform.GetComponent<CapsuleCollider>().enabled = false;
        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            return;
        }

        public void TickFixed()
        {
            return;
        }

        public void TickLate()
        {
            return;
        }
    }
}

