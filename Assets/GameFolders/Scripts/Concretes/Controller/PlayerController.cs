using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Input;
using UdemyProject3.Abstract.Movements;
using UdemyProject3.Animations;
using UdemyProject3.Movements;
using UnityEngine;

namespace UdemyProject3.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movements Specs")]
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] Transform _turnTransform;
        [SerializeField] WeaponController currentWeaponController;

        IInputReader _iInputReader;
        IRotator _xRotator, _yRotator;
        IMover _iMover;
        CharacterAnimation _animations;

        public Transform TurnTransfor => _turnTransform;

        Vector3 _direction;
        
        private void Awake()
        {
            _iInputReader= GetComponent<IInputReader>();
            _iMover = new MoveWithCharacterController(this);
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
                currentWeaponController.CanAttack();
            }
        }

        private void FixedUpdate()
        {
            _iMover.MoveAction(_direction, _moveSpeed);
            

        }

        private void LateUpdate()
        {
            _animations.MoveAnimation(_direction.magnitude);
        }
    }

}
