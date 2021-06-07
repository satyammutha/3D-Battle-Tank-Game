using UnityEngine;

public class MonoSingletonGeneric<T> : MonoBehaviour where T:MonoBehaviour
{
    public static T Instance;
    static object m_lock = new Object();

    public static T GetInstance()
    {
        lock (m_lock)
        {
            if(Instance == null)
            {
                Instance = FindObjectOfType<T>();
                if(Instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).ToString();
                    Instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }
            }
        }
        return Instance;
    }
}
