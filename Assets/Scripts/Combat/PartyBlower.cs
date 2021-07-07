using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyBlower : MonoBehaviour
{
    public Transform targetDireita;
    public Transform targetEsquerda;
    public float speed;
    public float delay;
    private float initTime;
    private bool indoPraDireita = true;
    // Start is called before the first frame update
    void Start()
    {
        initTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (initTime + delay > Time.fixedTime)
            return;

        if (indoPraDireita)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,
             targetDireita.position, step);
            if (Mathf.Abs(transform.position.x - targetDireita.position.x) < 0.5)
                indoPraDireita = false;
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,
             targetEsquerda.position, step);
            if (Mathf.Abs(transform.position.x - targetEsquerda.position.x) < 0.5)
                indoPraDireita = true;
        }
        
    }
}
