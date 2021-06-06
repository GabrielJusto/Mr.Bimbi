using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Combat_Player : MonoBehaviour
{

    public Text life;

    private int lifeCount = 10;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeupdate();
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

    private void lifeupdate()
    {
        life.text = lifeCount.ToString() + "x" ;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        lifeCount --;
        
    }
}
