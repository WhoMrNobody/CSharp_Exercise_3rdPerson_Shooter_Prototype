using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3.Abstract.Input
{
    public interface IInputReader
    {
        Vector3 Direction { get; }
    }
}
