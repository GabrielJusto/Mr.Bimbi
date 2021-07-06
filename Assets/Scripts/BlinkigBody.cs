using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkigBody : MonoBehaviour
{
    private Material body; 
    public float time = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Renderer>().material;

    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch (body.color.a.ToString())
            {
                case "0":
                    body.color = new Color(body.color.r, body.color.g, body.color.b, 1);
                    yield return new WaitForSeconds(time);
                    break;
                case "1":
                    body.color = new Color(body.color.r, body.color.g, body.color.b, 0);
                    yield return new WaitForSeconds(time);
                    break;
            }
        }
    }

    public void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");

    }

    public void StopBlinking()
    {
        StopCoroutine("Blink");

    }

}

