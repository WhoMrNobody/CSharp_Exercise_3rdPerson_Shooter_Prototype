using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3.ScritableObject
{
    [CreateAssetMenu(fileName ="Health Info",menuName = "Create New Health Properties", order =51)]
    public class HealthSO : ScriptableObject
    {
        [SerializeField] int _maxHealth;

        public int MaxHealth => _maxHealth;
    }

}
