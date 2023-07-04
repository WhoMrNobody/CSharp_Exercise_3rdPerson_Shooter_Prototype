using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Movements;
using UnityEngine;

namespace UdemyProject3.Movements
{
    public class RibRotator : IRotator
    {
        Transform _transform;
        float _tilt;
        public RibRotator(Transform transform)
        {
            transform = _transform;
        }
        public void RotationAction(float direction, float speed)
        {
            direction *= speed * Time.deltaTime;
            _tilt = Mathf.Clamp(_tilt - direction, -30f, 30f);

            _transform.Rotate(new Vector3(0, 0, _tilt));
        }
    }
}

