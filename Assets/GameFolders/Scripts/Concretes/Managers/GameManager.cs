using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.Helpers;
using UnityEngine;

namespace UdemyProject3.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        void Awake()
        {
            SetSingletonThisGameObject(this);
        }
    }
}

