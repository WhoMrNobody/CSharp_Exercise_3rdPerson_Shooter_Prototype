using UdemyProject3.Abstract.Controllers;
using UdemyProject3.Abstract.Movements;
using UdemyProject3.Animations;
using UdemyProject3.Combats;
using UnityEngine;

namespace UdemyProject3.Abstract.Controllers
{
    public interface IEnemyController : IEntityController
    {
        IMover Mover { get; }
        InventoryController InventoryController { get; }
        CharacterAnimation CharacterAnimation { get; }
        public Dead Dead { get;}
        Transform Target { get; set; }
        float Magnitude { get;  }
    }
}

