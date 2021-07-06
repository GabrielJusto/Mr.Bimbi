
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    static DoNotDestroy instance;
    void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
