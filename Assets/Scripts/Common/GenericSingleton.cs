using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance 
    { 
        get 
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                // if it's null again create a new object
                // and attach the generic instance
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                }
            }

            return _instance;
        } 
    }

    public virtual void Awake()
    {
        // create the instance
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
