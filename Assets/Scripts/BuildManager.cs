using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;
    public GameObject standartTurretPrefab;
    public GameObject MissileLauncherPrefab;

    public static BuildManager instance;

    private void Awake()
    {
        if (instance)
        {
            Debug.Log("cant build here");
            return;
        }
        instance = this;
        
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
    public bool CanBuild{ get { return turretToBuild != null;}  }

    public void BuildTurretOn(Node node)
    {
        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.transform.position + node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
}
