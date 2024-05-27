using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy _instance;

    public static DontDestroy Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DontDestroy>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
}
