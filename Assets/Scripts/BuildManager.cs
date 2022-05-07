using System;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    public static BuildManager instance;
    public GameObject buildEffect;
    private void Awake()
    {
        if (instance)
        {
            Debug.Log("cant build here");
            return;
        }
        instance = this;
        
    }

    public void SelectNode(Node node)
    {
        if (selectedNode==node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public bool CanBuild{ get { return turretToBuild != null;}  }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
