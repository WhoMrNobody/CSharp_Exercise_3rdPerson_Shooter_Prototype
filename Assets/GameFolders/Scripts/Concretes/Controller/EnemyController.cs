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
        IMover _mover;
        IHealth _iHealth;
        CharacterAnimation _characterAnimation;
        NavMeshAgent _navMeshAgent;
        InventoryController _inventoryController;
        Transform _playerTransform;
        bool _canAttack;
        void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _characterAnimation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _inventoryController = GetComponent<InventoryController>();
            _iHealth = GetComponent<IHealth>();
        }

        void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>().transform;
        }


        void Update()
        {   
            if(_iHealth.IsDead) return;

            _mover.MoveAction(_playerTransform.position, 10f);

            _canAttack = Vector3.Distance(_playerTransform.position, this.transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;
        }

        void FixedUpdate()
        {
            if(_canAttack) {

                _inventoryController.CurrentWeapon.CanAttack();
            }
        }

        void LateUpdate()
        {
            _characterAnimation.MoveAnimation(_navMeshAgent.velocity.magnitude);
            _characterAnimation.AttackAnimation(_canAttack);
        }
    }
}

