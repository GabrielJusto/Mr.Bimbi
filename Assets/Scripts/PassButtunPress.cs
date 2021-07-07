using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassButtunPress : MonoBehaviour
{
    public Sprite pressSprite;

    private SpriteRenderer button;

    private Sprite unpressSprite;

    private bool isPress;
    // Start is called before the first frame update
    void Start()
    {
        isPress = false;
        button = gameObject.GetComponent<SpriteRenderer>();
        unpressSprite = button.sprite;
    }

    // Update is called once per frame
    void Update()
    {
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
        isPress = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPress = false;
    }
}
