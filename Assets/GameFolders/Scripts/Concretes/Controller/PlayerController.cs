using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Abstract.Input;
using UdemyProject3.Abstract.Movements;
using UdemyProject3.Animations;
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

        public Transform TurnTransfor => _turnTransform;
        public IMover Mover { get; private set; }

        IInputReader _iInputReader;
        IRotator _xRotator, _yRotator;
        CharacterAnimation _animations;
        Vector3 _direction;
        InventoryController _inventoryController;
        private void Awake()
        {
            _iInputReader= GetComponent<IInputReader>();
            _inventoryController = GetComponent<InventoryController>();
            Mover = new MoveWithCharacterController(this);
            _animations = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
        }

        private void Update()
        {
            _direction = _iInputReader.Direction;
            
            _xRotator.RotationAction(_iInputReader.Rotation.x, _turnSpeed);
            _yRotator.RotationAction(_iInputReader.Rotation.y, _turnSpeed);


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
            Mover.MoveAction(_direction, _moveSpeed);
            

        }

        private void LateUpdate()
        {
            _animations.MoveAnimation(_direction.magnitude);
            _animations.AttackAnimation(_iInputReader.IsAttackPressed);
        }
    }

}
