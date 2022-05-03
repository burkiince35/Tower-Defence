using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject turretToBuild;
    public GameObject standartTurretPrefab;

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
    public void Start()
    {
        turretToBuild = standartTurretPrefab;
    }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
