
using UnityEngine;

public class Catch : MonoBehaviour
{

    bool catched;
    public GameObject player;
    public GameObject pickUp;



    // Start is called before the first frame update
    void Start()
    {
        catched = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 1
            && Mathf.Abs(transform.position.y - player.transform.position.y) < 1
            && Input.GetKeyDown("z") && !catched)
        {
            catched = true;
            this.transform.parent = pickUp.transform;
        }
        else 
        {
            if (catched)
            {
                if (Input.GetKeyDown("z"))
                {
                    catched = false;
                    this.transform.parent = null;
                    gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                }
            }
        }
        
    }
}
