namespace CustomUtils
{
    using UnityEngine;

    public class SingletonMono<T>: MonoBehaviour where  T : MonoBehaviour
    {
        public static T _Instance { get; private set; }

        protected virtual void Awake()
        {
            if (_Instance == null)
            {
                _Instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public class Singleton<T> where T : Singleton<T>, new()
    {
        public static T _Instance { get; private set; }

        public Singleton()
        {
            if (_Instance == null)
            {
                _Instance = this as T;
            }
            else
            {
                Debug.LogError("[Singleton] Instance (" + typeof(T).Name + ") existed!");
            }
        }
    }
}