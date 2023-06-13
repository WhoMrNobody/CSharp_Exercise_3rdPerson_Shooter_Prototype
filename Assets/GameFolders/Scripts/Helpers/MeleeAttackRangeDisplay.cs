using System.Collections;
using System.Collections.Generic;
using UdemyProject3.ScritableObject;
using UnityEngine;

namespace UdemyProject3.Helpers
{
    public class MeleeAttackRangeDisplay : MonoBehaviour
    {
        [SerializeField] AttackSO _attackSO;

        void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, _attackSO.WeaponRange);
        }
    }
}

