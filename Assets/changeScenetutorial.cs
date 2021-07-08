using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenetutorial : MonoBehaviour
{
    public string sceneToLoad;

    private void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Butler"))
        {

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
