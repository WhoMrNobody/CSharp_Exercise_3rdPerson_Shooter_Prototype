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

        IInputReader _iInputReader;
        IMover _iMover;
        CharacterAnimation _animations;

        Vector3 _direction;
        private void Awake()
        {
            _iInputReader= GetComponent<IInputReader>();
            _iMover = new MoveWithCharacterController(this);
            _animations = new CharacterAnimation(this);
        }

        private void Update()
        {
            _direction = _iInputReader.Direction;
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
