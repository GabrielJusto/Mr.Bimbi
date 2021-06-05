using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Player : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector = transform.position;
        if(Input.GetKey("right"))
        {
            vector.x = vector.x + (Time.deltaTime * speed);
            transform.position = vector;
        }else if(Input.GetKey("left"))
        {
            vector.x = vector.x - (Time.deltaTime * speed);
            transform.position = vector;
        }else if(Input.GetKey("up"))
        {
            
            vector.y = vector.y + (Time.deltaTime * speed);
            transform.position = vector;
        }else if(Input.GetKey("down"))
        {
            
            vector.y = vector.y - (Time.deltaTime * speed);
            transform.position = vector;
        }
    }
}
