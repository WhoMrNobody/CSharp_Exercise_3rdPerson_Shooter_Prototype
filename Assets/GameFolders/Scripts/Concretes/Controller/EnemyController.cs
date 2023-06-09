using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Combat;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Abstract.Movements;
using UdemyProject3.Animations;
using UdemyProject3.Movements;
using UnityEngine;
using UnityEngine.AI;

namespace UdemyProject3.Controller
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] Transform _playerPrefab;

        IMover _mover;
        IHealth _iHealth;
        CharacterAnimation _characterAnimation;
        NavMeshAgent _navMeshAgent;
        void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _characterAnimation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _iHealth = GetComponent<IHealth>();
        }

        
        void Update()
        {   
            if(_iHealth.IsDead) return;

            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }

        void LateUpdate()
        {
            _characterAnimation.MoveAnimation(_navMeshAgent.velocity.magnitude);
        }
    }
}

