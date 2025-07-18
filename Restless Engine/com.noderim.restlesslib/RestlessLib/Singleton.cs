using UnityEngine;

namespace RestlessLib
{
    /// <summary>
    /// Singleton Base class to be inherited by other classes
    /// </summary>
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject); // Avoid duplicates
                return;
            }

            Instance = this as T;
        }

        protected virtual void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }



    public abstract class SingletonPersistent<T> : Singleton<T> where T : SingletonPersistent<T>
    {
        protected override void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            base.Awake();
        }
    }
}
