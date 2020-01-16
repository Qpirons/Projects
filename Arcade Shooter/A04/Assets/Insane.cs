using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Insane : MonoBehaviour
{
    public Button btn;
    GameObject Met;
    // Start is called before the first frame update
    void Start()
    {
        Button isn = btn.GetComponent<Button>();
        isn.onClick.AddListener(SetDif);
    }

    // Update is called once per frame
    void SetDif()
    {
        GameObject Spawn = GameObject.Find("GameManager");
        SpawnMeteor IE = Spawn.GetComponent<SpawnMeteor>();
        IE.spawnTime = .05f;
        Time.timeScale = 1;
    }
}