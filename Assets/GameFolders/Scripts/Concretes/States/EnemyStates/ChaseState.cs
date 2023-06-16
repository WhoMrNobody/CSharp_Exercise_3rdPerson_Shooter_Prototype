using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Abstract.States;
using UnityEngine;

namespace UdemyProject3.States.EnemyStates
{
    public class ChaseState : IState
    {
        float _speed = 10f;
        IEnemyController _enemyController;
        public ChaseState(IEnemyController enemyController)
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
            _enemyController.Mover.MoveAction(_enemyController.Target.position, _speed);
        }

        public void TickFixed()
        {
           
        }

        public void TickLate()
        {
            _enemyController.CharacterAnimation.MoveAnimation(_enemyController.Magnitude);
        }
    }
}

