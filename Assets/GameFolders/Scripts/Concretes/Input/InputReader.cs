using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UdemyProject3.Input
{
    public class InputReader : MonoBehaviour, IInputReader
    {
        public Vector3 Direction { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 oldDirection = context.ReadValue<Vector2>();

            Direction = new Vector3(oldDirection.x, 0f, oldDirection.y);

        }
      
    }
}

