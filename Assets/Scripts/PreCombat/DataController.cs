using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public RoundData[] allround;

    private int roundIndex;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene("PreCombat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRoundData(int round)
    {
        roundIndex = round;
    }

    public RoundData GetCurrentRoundData()
    {
        return allround[roundIndex];
    }
}
