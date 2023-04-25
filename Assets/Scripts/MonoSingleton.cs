using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour
    where T : MonoSingleton<T>
{
    public static T Instance { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null) Instance = (T)this;
        else Destroy(gameObject);
    }
}