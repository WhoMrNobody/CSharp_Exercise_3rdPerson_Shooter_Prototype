using UdemyProject3.Abstract.Movements;
using UnityEngine;

namespace UdemyProject3.Abstract.Controllers
{
    public interface IEntityController 
    {
        public Transform transform { get; }
        IMover Mover { get; }
    }
}

