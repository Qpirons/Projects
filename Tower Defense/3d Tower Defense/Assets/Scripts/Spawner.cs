using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public Transform enemy;
    public Transform Startloc;
    public float CountdownTimer = 5f;
    private float countdown = 2f;
    private float duration;
    public Text timerText;
    private int wave = 0;
    public Enemy Healthincr;
    void Start()
    {
        Healthincr.Health = 100;
    }

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(Spawn());
            countdown = CountdownTimer;
        }
        countdown -= Time.deltaTime;
        duration += Time.deltaTime;
        timerText.text = "Time Survived :" + Mathf.Round(duration).ToString();
    }
   IEnumerator Spawn()
    {
        ++wave;
        for (int i = 0; i < wave; ++i)
        {
            CreateEnemy();
            yield return new WaitForSeconds(0.25f);
        }
        if(wave >= 5 && wave < 10)
        {
            Healthincr.Health += 5;
        }
        else if(wave >= 10)
        {
            Healthincr.Health += 10;
        }
    }

    void CreateEnemy()
    {
        Instantiate(enemy,Startloc.position, Startloc.rotation);
    }
}
