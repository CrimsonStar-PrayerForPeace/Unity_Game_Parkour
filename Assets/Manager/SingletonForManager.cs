using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SingletonForManager<T> : MonoBehaviour where T : SingletonForManager<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<T>();

                if(_instance == null)
                {
                    GameObject managerObj = new GameObject(typeof(T).Name);
                    _instance = managerObj.AddComponent<T>();
                }

            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if(_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);

            ManagerAwake();
        }

        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if(_instance != null)
        {
            _instance = null;
        }
    }

    protected virtual void ManagerAwake(){}
}
