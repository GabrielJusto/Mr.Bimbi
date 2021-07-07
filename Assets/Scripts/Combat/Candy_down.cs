using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy_down : MonoBehaviour
{
    public float speed;
    public float x_min;
    public float x_max;
    public float y_target;


    private Vector2 target;
    private Vector2 start;
    private float currentTime;
    private float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        target = new Vector2(Random.Range(x_min, x_max), y_target);
        float distance = Vector2.Distance(start, target);
        currentTime = 0f;
        totalTime = distance / speed;
    }

    // Update is called once per frame
    void Update()
    {
        float current = currentTime / totalTime;
        currentTime += Time.deltaTime;

        float t = current;
        t = t * t * (3f - 2f * t);

        Vector2 new_position = Vector2.Lerp(start, target, t);
        transform.position = new_position;

        if(current >= 0.8f)
        {
            Debug.Log("Entrou Aqui!");
            Destroy(this.gameObject);
        }

    }
}
