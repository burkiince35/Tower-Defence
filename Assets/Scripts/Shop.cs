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
    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile Launcher purchased");
        buildmanager.SetTurretToBuild(buildmanager.MissileLauncherPrefab);
    }
}
