using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Combat;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Abstract.Movements;
using UdemyProject3.Animations;
using UdemyProject3.Combats;
using UdemyProject3.Managers;
using UdemyProject3.Movements;
using UdemyProject3.States.EnemyStates;
using UnityEngine;
using UnityEngine.AI;

namespace UdemyProject3.Controller
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        IHealth _iHealth;
        NavMeshAgent _navMeshAgent;
        StateMachines _stateMachines;

        public IMover Mover { get; private set; }
        public bool CanAttack => Vector3.Distance(Target.position, this.transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;

        public InventoryController InventoryController { get; private set; }
        public CharacterAnimation CharacterAnimation { get; private set; }
        public Transform Target { get; set; }

        public float Magnitude => _navMeshAgent.velocity.magnitude;

        public Dead Dead { get; private set; }

        void Awake()
        {
            Mover = new MoveWithNavMesh(this);
            CharacterAnimation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            InventoryController = GetComponent<InventoryController>();
            Dead = GetComponent<Dead>();
            _iHealth = GetComponent<IHealth>();
            _stateMachines = new StateMachines();
        }

        void Start()
        {
            Target = FindObjectOfType<PlayerController>().transform;

            AttackState attackState = new AttackState(this);
            ChaseState chaseState = new ChaseState(this);
            DeadState deadState = new DeadState(this);
            

            _stateMachines.AddState(chaseState, attackState, () => CanAttack);
            _stateMachines.AddState(attackState, chaseState, () => !CanAttack);
            _stateMachines.AddAnyState(deadState, () => _iHealth.IsDead);

            _stateMachines.SetState(chaseState);
        }


        void Update()
        {   
            if(_iHealth.IsDead) return;

            _stateMachines.Tick();
        }

        void FixedUpdate()
        {
            _stateMachines.TickFixed();
        }

        void LateUpdate()
        {
            _stateMachines.TickLate();
        }

        void OnDestroy()
        {
            EnemyManager.Instance.RemoveEnemyController(this);
        }
    }

}

