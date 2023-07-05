using System.Collections;
using System.Collections.Generic;
using UdemyProject3.ScritableObject;
using UnityEngine;

namespace UdemyProject3.Abstract.Controllers
{
    public interface IAttackType    
    {
        void AttackAction();

        public AttackSO AttackInfo { get; }
    }
}

