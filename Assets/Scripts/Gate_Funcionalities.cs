using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Funcionalities : MonoBehaviour
{
    public PassButtunPress[] buttons;
    void Start()
    {
        buttons = GameObject.FindObjectsOfType<PassButtunPress>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Allbuttonpress())
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    bool Allbuttonpress()
    {
        bool ret = true;
        foreach(PassButtunPress but in buttons)
        {
            if(but == null)
            {
                continue;
            }
            ret = ret && but.isPress;
        }

        return ret;
    }
}
