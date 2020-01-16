using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hard : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        Button hrd = btn.GetComponent<Button>();
        hrd.onClick.AddListener(SetDif);
    }

    // Update is called once per frame
    void SetDif()
    {
        GameObject Spawn = GameObject.Find("GameManager");
        SpawnMeteor HD = Spawn.GetComponent<SpawnMeteor>();
        HD.spawnTime = .10f;
        Time.timeScale = 1;
    }
}