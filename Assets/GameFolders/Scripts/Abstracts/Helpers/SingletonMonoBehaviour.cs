using UnityEngine;

namespace UdemyProject3.Abstract.Helpers
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        public static T Instance {  get; private set; }

        protected void SetSingletonThisGameObject(T instance)
        {
            if (instance != null)
            {
                Instance = instance;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

    }
}

