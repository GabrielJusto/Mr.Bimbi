using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassButtunPress : MonoBehaviour
{
    public Sprite pressSprite;

    public string color;

    public GameObject box;

    private SpriteRenderer button;

    private Vector2 box_vector;

    private Sprite unpressSprite;

    private float distance;

    public bool isPress;
    // Start is called before the first frame update
    void Start()
    {
        if(box == null)
        {
            box = GameObject.Find("Box_" + color);
        }
        box_vector = box.transform.position;
        isPress = false;
        button = gameObject.GetComponent<SpriteRenderer>();
        unpressSprite = button.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        box_vector = box.transform.position;
        distance = Vector2.Distance(box_vector, gameObject.transform.position);
        if (isPress)
        {
            button.sprite = pressSprite;
        }
        else
        {
            button.sprite = unpressSprite;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(distance);
        if (distance < 1f)
        {
            isPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (distance > 1f)
        {
            isPress = false;
        }
    }
}
