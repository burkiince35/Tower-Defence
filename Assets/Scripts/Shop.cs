using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildmanager;

    public TurretBlueprint standartTurret;
    public TurretBlueprint MissileLauncher;
    public TurretBlueprint LaserBeamer;
    private void Start()
    {
        buildmanager = BuildManager.instance;
    }
    public void SelectStandartTurret()
    {
        Debug.Log("standart turret purchased");
        buildmanager.SelectTurretToBuild(standartTurret);
    } 
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher purchased");
        buildmanager.SelectTurretToBuild(MissileLauncher);
    } 
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer purchased");
        buildmanager.SelectTurretToBuild(LaserBeamer);
    }
}
