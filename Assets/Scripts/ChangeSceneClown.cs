using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneClown : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject butler;
    public GameObject box;

    private void Start()
    {
        if(butler == null)
        {
            butler = GameObject.Find("Butler");
        }
        if(box == null)
        {
            box = GameObject.Find("Waffle");
        }
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name.Equals("Butler"))
        {
            butler.GetComponent<Renderer>().enabled = false;
            box.GetComponent<Renderer>().enabled = false;

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
