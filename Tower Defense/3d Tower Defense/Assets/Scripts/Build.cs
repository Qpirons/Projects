using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    private TurretBlueprint buildTurret;
    public static Build instance;
    
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CanBuild { get { return buildTurret != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= buildTurret.cost; } }
    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        buildTurret = turretBlueprint;
    }
    public void BuildOn(Node node)
    {
        if(PlayerStats.Money < buildTurret.cost)
        {
            return;
        }
       PlayerStats.Money -= buildTurret.cost;
       GameObject tempTurret = Instantiate(buildTurret.prefab, node.BuildPosition(), Quaternion.identity);
       node.turret = tempTurret;
    }
}
