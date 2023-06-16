using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Abstract.Movements;
using UdemyProject3.Animations;
using UnityEngine;

namespace UdemyProject3.Abstract.Controllers
{
    public interface IEnemyController : IEntityController
    {
        IMover Mover { get; }
        InventoryController InventoryController { get; }
        CharacterAnimation CharacterAnimation { get; }
        Transform Target { get; set; }
        float Magnitude { get;  }
    }
}

