
using UnityEngine;

public class Catch : MonoBehaviour
{

    bool catched;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        catched = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Mathf.Abs(transform.position.x - player.transform.position.x) < 1.2
            && Mathf.Abs(transform.position.y - player.transform.position.y) <1.2
            && Input.GetKeyDown("space"))
        {
            catched = true;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        
        if(catched)
        { 
            transform.position = new Vector2(player.transform.position.x - 0.2f, player.transform.position.y - 0.2f);
            if(Input.GetKeyDown("z"))
            {
                catched = false;
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }

        
    }
}
