using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy_Enemy : MonoBehaviour
{
    public GameObject[] candys;
    public float spawnTime = 0.05f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CandysWave());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void spawnEnemy()
    {

        GameObject gameObject1 = Instantiate((GameObject)candys[(int)Random.Range(0, 4)]);
        GameObject a = gameObject1;
        a.transform.position = new Vector2(0, 4);
    }

    IEnumerator CandysWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnEnemy();
        }
    }
}
