using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    public float speed;

    public Transform butler;

    
    // Start is called before the first frame update
    void Start()
    {
        butler = GameObject.Find("Butler").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float camera_x = transform.position.x;
        float camera_y = transform.position.y;

        if(butler.position.x < 6.9 && butler.position.x > -6.9)
        {
            camera_x = butler.position.x;
        }
        
        if( butler.position.y < 6.9 &&  butler.position.y > -6.9)
        {
            camera_y = butler.position.y;
        }
        
        transform.position = new Vector3 (camera_x , camera_y, -1);


    }
}
