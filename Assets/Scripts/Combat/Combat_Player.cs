using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Combat_Player : MonoBehaviour
{

    public float time;

    
    public Text textTime;
    public string sceneGameOver;

    public string winScene;

    public Text life;

    private int lifeCount = 5;
    public float speed;
    private Color originalColor;

    public float blink;
    public float immuned;
    public Renderer body;

    private float blinkTime = 0.1f;
    private float immunedTime;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        lifeupdate();
        countdown();
        ImmunedBlink();
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

    private void ImmunedBlink()
    {
        if (immunedTime > 0)
        {
            immunedTime -= Time.deltaTime;

            blinkTime -= Time.deltaTime;
            if(blinkTime <= 0)
            {
                body.enabled = !body.enabled;

                blinkTime = blink;
            }
            if (immunedTime <= 0)
            {
                body.enabled = true;
            }
        }
    }
    private void countdown()
    {
        time -= Time.deltaTime;
        textTime.text = Mathf.Round(time).ToString() + "s";
        if(textTime.text.Equals("0s"))
        {
          
            SceneManager.LoadScene(winScene);
        }

    }
    private void lifeupdate()
    {
        life.text = lifeCount.ToString() + "x" ;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (immunedTime <= 0)
        {
            lifeCount--;
            if (lifeCount == 0)
            {
                SceneManager.LoadScene(sceneGameOver);
            }
            else
            {
                immunedTime = immuned;
                body.enabled = false;

                blinkTime = blink;
            }
        }
    }
}
