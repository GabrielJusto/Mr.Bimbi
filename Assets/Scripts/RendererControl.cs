using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererControl : MonoBehaviour
{
    public string[] objects;
    // Start is called before the first frame update
    void Start()
    {
        foreach (string name in objects)
        {
            
            if (!GameObject.Find(name).GetComponent<Renderer>().enabled)
            {
                GameObject.Find(name).GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
