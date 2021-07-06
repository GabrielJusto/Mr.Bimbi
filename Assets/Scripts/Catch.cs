
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
        
        if(Mathf.Abs(transform.position.x - player.transform.position.x) < 0.3
            && Mathf.Abs(transform.position.y - player.transform.position.y) < 0.3)
            catched = true;
        
        if(catched)
            transform.position = new Vector2(player.transform.position.x - 0.2f, player.transform.position.y - 0.2f);

        
    }
}
