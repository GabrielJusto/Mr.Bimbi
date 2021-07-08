using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Transition : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    public void pressButton()
    {
        SceneManager.LoadScene(scene);
    }
}
