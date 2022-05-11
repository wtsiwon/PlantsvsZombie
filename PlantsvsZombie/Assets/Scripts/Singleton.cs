using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : class
{
    public static T Instance { get; private set; }

    private void Awake()
    {
        Instance = GetComponent<T>();
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
