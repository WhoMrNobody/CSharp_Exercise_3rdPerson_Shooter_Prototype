using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3.Controller
{
    public class BulletFXController : MonoBehaviour
    {
        [SerializeField] float _maxLifeTime = 5f;
        [SerializeField] float _moveSpeed = 100f;

        ParticleSystem _particleSystem;
        Rigidbody _rb;

        float _currentLifeTime = 0f;

        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _particleSystem=GetComponentInChildren<ParticleSystem>();
        }

        void Start()
        {
            _particleSystem.Play();
        }

        void Update()
        {
            _currentLifeTime += Time.deltaTime;

            if(_currentLifeTime > _maxLifeTime)
            {
                Destroy(this.gameObject);
            }
            
        }

        void OnTriggerEnter(Collider coll)
        {
            Destroy(this.gameObject);
        }

        public void SetDirection(Vector3 direction)
        {
            _rb.velocity = direction * _moveSpeed;
        }
    }

}
