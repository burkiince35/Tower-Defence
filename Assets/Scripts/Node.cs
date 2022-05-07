using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretblueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    
    
    BuildManager buildmanager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildmanager = BuildManager.instance;
    }

    private void OnMouseDown() // node a basýnca turret spawnlýyor.
    {
       
        if (turret!=null)
        {
            buildmanager.SelectNode(this);
            return;
        }
        if (!buildmanager.CanBuild) // herhangi turret butonuna basýlmadýysa node a basýnca biþi olmayacak.
        {
            return;
        }
        BuildTurret(buildmanager.GetTurretToBuild());
    }
    
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("you dont have money!");
            return;
        }
        PlayerStats.money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab,GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretblueprint = blueprint;
        GameObject effect = (GameObject)Instantiate(buildmanager.buildEffect,GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 4f);
        Debug.Log("turret build!");
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretblueprint.Upgradecost)
        {
            Debug.Log("you dont have money to upgrade!");
            return;
        }
        PlayerStats.money -= turretblueprint.Upgradecost;
        Destroy(turret);
        GameObject _turret = (GameObject)Instantiate(turretblueprint.Upgradedprefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        GameObject effect = (GameObject)Instantiate(buildmanager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 4f);
        isUpgraded = true;
        Debug.Log("turret upgraded!");
    }

    private void OnMouseEnter() // node un üzerine geldiðimizde rengi deðþiyor.
    {
        if (!buildmanager.CanBuild)
        {
            return;
        }
        if (buildmanager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    private void OnMouseExit() // üzerinden çýkýnca da rengi tekrardan eski halini alýyor.
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
