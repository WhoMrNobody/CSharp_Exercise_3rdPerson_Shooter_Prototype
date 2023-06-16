using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Abstract.States;
using UnityEngine;

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

        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            _currentTime += Time.deltaTime;

            if(_currentTime > _maxTime)
            {
                GameObject.Destroy(_enemyController.transform.gameObject);
            }
        }

        public void TickFixed()
        {
           
        }

        public void TickLate()
        {
            
        }
    }
}

