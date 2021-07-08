using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttunDoNotDestroy : MonoBehaviour
{
    static buttunDoNotDestroy instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
