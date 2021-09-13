using System;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T :MonoBehaviour
{
    private static T instance;

    public static T Instsance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this as T;
    }
}
