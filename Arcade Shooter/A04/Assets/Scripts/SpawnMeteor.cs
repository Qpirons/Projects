using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnMeteor : MonoBehaviour
{
    public GameObject Meteor;
    public float spawnTime = 0;
    private float timer = 0;
    private int randomNumber;

    void Update()
    {
        if (spawnTime != 0)
        {
            timer += Time.deltaTime;
            if (timer > spawnTime)
            {
                SpawnRandom();
                timer = 0;
            }
        }
    }
    public void SpawnRandom()
    {

        Vector2 top = new Vector2(Random.Range(-6f, 6f), 5f);
        Instantiate(Meteor, top, Quaternion.identity);
    }
}
