using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject turretToBuild;
    public GameObject standartTurretPrefab;
    public GameObject AnotherTurretPrefab;

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
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
    public GameObject GetTurretToBuild() // içinde spawnlancak olan objeyi döndürüyor.
    {
        return turretToBuild;
    }
}
