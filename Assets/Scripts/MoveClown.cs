using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClown : MonoBehaviour
{
    public Transform target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        // Move objeto na direção do target
        transform.position = Vector2.MoveTowards(transform.position,
            target.position, step);
        if (Vector2.Distance(transform.position, target.position) < 0.1)
        {
            float x = Random.Range(-11.5f, 11.5f);
            float y = Random.Range(-4.5f, 8.5f);
            target.position = new Vector2(x, y);
        }
    }
}
