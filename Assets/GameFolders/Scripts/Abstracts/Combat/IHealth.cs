using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3.Abstract.Combat
{
    public interface IHealth
    {
        bool IsDead { get; }
        void TakeDamage(int damage);
    }
}

