using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_enemy : MonoBehaviour
{

    public GameObject balloon;
    public float spawnTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(balloonWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(balloon) as GameObject;
        a.transform.position = new Vector2(Random.Range(-11,11), -15);
    }

    IEnumerator balloonWave ()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnEnemy();
        }
    }
}
