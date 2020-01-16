using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Easy : MonoBehaviour
{
    public GameObject menu;
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        Button esy = btn.GetComponent<Button>();
        esy.onClick.AddListener(SetDif);
    }

    // Update is called once per frame
    void SetDif()
    {
        GameObject Spawn = GameObject.Find("GameManager");
        SpawnMeteor EY = Spawn.GetComponent<SpawnMeteor>();
        EY.spawnTime = .5f;
        Time.timeScale = 1;
    }
}
