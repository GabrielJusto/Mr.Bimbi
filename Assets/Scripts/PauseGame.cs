using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void DesPause()
    {
        panel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
