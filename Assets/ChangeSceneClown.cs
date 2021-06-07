using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneClown : MonoBehaviour
{
    public string sceneToLoad;
    

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name.Equals("Butler"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
