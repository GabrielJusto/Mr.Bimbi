using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butlerDoNotDestory : MonoBehaviour
{
    static butlerDoNotDestory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log(instance);
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
