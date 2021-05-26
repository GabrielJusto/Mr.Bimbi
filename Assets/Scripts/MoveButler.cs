using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButler : MonoBehaviour
{

    public float speed;

    private SpriteRenderer spriteRenderer;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 vector = transform.position;
        if(Input.GetKey("right"))
        {
            animator.SetBool("walking", true);
            spriteRenderer.flipX = true;
            vector.x = vector.x + (Time.deltaTime * speed);
            transform.position = vector;
        }else if(Input.GetKey("left"))
        {
            animator.SetBool("walking", true);
            spriteRenderer.flipX = false;
            vector.x = vector.x - (Time.deltaTime * speed);
            transform.position = vector;
        }else if(Input.GetKey("up"))
        {
            animator.SetBool("walking", true);
            vector.y = vector.y + (Time.deltaTime * speed);
            transform.position = vector;
        }else if(Input.GetKey("down"))
        {
            animator.SetBool("walking", true);
            vector.y = vector.y - (Time.deltaTime * speed);
            transform.position = vector;
        }else
        {
            animator.SetBool("walking", false);
        }
    }
}
