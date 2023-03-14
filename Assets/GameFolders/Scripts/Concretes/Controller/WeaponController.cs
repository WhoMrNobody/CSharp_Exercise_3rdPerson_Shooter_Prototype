using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3.Controller
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool canFire;
        [SerializeField] float attackMaxDelay = 2.5f;
        [SerializeField] Camera camera;
        [SerializeField] float weaponRange = 100f;
        [SerializeField] LayerMask layerMask;

        float _currentTime = 0f;
        // Update is called once per frame
        void Update()
        {
            _currentTime += Time.deltaTime;

            canFire = _currentTime > attackMaxDelay;

        }

        public void CanAttack()
        {
            if(!canFire) { return;  }

            Ray ray = camera.ViewportPointToRay(Vector3.one / 2);

            if(Physics.Raycast(ray, out RaycastHit _hit, weaponRange, layerMask))
            {
                Debug.Log(_hit.collider.gameObject.name);
            }

            _currentTime = 0f;
        }
    }
}

