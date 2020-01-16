using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Med : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        Button med = btn.GetComponent<Button>();
        med.onClick.AddListener(SetDif);
    }

    // Update is called once per frame
    void SetDif()
    {
        GameObject Spawn = GameObject.Find("GameManager");
        SpawnMeteor MD = Spawn.GetComponent<SpawnMeteor>();
        MD.spawnTime = .25f;
        Time.timeScale = 1;
    }
}
