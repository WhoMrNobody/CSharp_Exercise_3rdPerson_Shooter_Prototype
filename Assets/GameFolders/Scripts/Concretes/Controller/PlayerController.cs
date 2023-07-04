using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Combat;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Abstract.Input;
using UdemyProject3.Abstract.Movements;
using UdemyProject3.Animations;
using UdemyProject3.Managers;
using UdemyProject3.Movements;
using UnityEngine;

namespace UdemyProject3.Controller
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [Header("Movements Specs")]
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] Transform _turnTransform;
        [SerializeField] Transform _ribTransform;

        public Transform TurnTransfor => _turnTransform;

        IInputReader _iInputReader;
        IRotator _xRotator, _yRotator;
        IRotator _ribRotator;
        IMover _mover;
        IHealth _health;
        CharacterAnimation _animations;
        Vector3 _direction;
        Vector3 _rotation;
        InventoryController _inventoryController;
        private void Awake()
        {
            _iInputReader= GetComponent<IInputReader>();
            _inventoryController = GetComponent<InventoryController>();
            _health = GetComponent<IHealth>();
            _mover = new MoveWithCharacterController(this);
            _ribRotator = new RibRotator(_ribTransform);
            _animations = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
        }

        void OnEnable()
        {
            _health.OnDead += () => _animations.DeadAnimation("isDying");
            EnemyManager.Instance.Targets.Add(this.transform);
        }

        void OnDisable()
        {
            EnemyManager.Instance.Targets.Remove(this.transform);
        }

        private void Update()
        {   
            if(_health.IsDead) return;

            _direction = _iInputReader.Direction;
            _rotation = _iInputReader.Rotation;
            
            _xRotator.RotationAction(_rotation.x, _turnSpeed);
            _yRotator.RotationAction(_rotation.y, _turnSpeed);


            if (_iInputReader.IsAttackPressed)
            {
                _inventoryController.CurrentWeapon.CanAttack();
            }

            if(_iInputReader.isInventoryButtonPressed)
            {
                _inventoryController.ChangeWeapon();
            }
        }

        private void FixedUpdate()
        {   
            if(_health.IsDead) return;

            _mover.MoveAction(_direction, _moveSpeed);
            
        }

        private void LateUpdate()
        {   
            if(_health.IsDead) return;

            _animations.MoveAnimation(_direction.magnitude);
            _animations.AttackAnimation(_iInputReader.IsAttackPressed);

            //_ribRotator.RotationAction(_rotation.y * -1, _turnSpeed);
        }
    }

}
