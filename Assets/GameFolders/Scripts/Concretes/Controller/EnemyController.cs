using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Abstract.Movements;
using UdemyProject3.Movements;
using UnityEngine;


namespace UdemyProject3.Controller
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] Transform _playerPrefab;

        IMover _mover;
        
        void Awake()
        {
            _mover = new MoveWithNavMesh(this);
        }

        
        void Update()
        {
            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }
    }
}

