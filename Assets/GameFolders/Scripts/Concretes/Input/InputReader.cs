using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

namespace UdemyProject3.Input
{
    public class InputReader : MonoBehaviour, IInputReader
    {
        public Vector3 Direction { get; private set; }

        public Vector2 Rotation { get; private set; }

        public bool IsAttackPressed { get; private set; }

        public bool isInventoryButtonPressed { get; private set; }

        int _index;
        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 oldDirection = context.ReadValue<Vector2>();

            Direction = new Vector3(oldDirection.x, 0f, oldDirection.y);

        }

        public void OnRotator(InputAction.CallbackContext context) 
        {
            Rotation= context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            IsAttackPressed = context.ReadValueAsButton();
        }

        public void OnInventoryPressed(InputAction.CallbackContext context)
        {
            if(isInventoryButtonPressed && context.action.triggered) { return; }

            StartCoroutine(WaitOnFrameAsync());
        }

        IEnumerator WaitOnFrameAsync()
        {
            isInventoryButtonPressed = true && _index % 2 == 0;
            yield return new WaitForEndOfFrame();
            isInventoryButtonPressed = false;

            _index++;
        }
    }
}

