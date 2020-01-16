using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    Build Builder;
    public TurretBlueprint standard;
    public TurretBlueprint laser;
    // Start is called before the first frame update
    void Start()
    {
        Builder = Build.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectTurret()
    {
        Debug.Log("Purchased Turret");
        Builder.SelectTurretToBuild(standard);
    }
    public void SelectLaser()
    {
        Debug.Log("Purchased Laser");
        Builder.SelectTurretToBuild(laser);
    }

}
