using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildmanager;

    private void Start()
    {
        buildmanager = BuildManager.instance;
    }
    public void PurchaseStandartTurret()
    {
        Debug.Log("standart turret purchased");
        buildmanager.SetTurretToBuild(buildmanager.standartTurretPrefab);
    } 
    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another turret purchased");
        buildmanager.SetTurretToBuild(buildmanager.AnotherTurretPrefab);
    }
}
