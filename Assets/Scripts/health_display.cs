using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_display : MonoBehaviour
{
    private int life;
    public Text lifeText;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        lifeText.text = life.ToString();
    }
}
