using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;

    private GameObject turret;

    BuildManager buildmanager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildmanager = BuildManager.instance;
    }

    private void OnMouseDown() // node a basýnca turret spawnlýyor.
    {
        if (buildmanager.GetTurretToBuild()==null) // herhangi turret butonuna basýlmadýysa node a basýnca biþi olmayacak.
        {
            return;
        }
        if (turret!=null)
        {
            return;
        }
        GameObject turretToBuild = buildmanager.GetTurretToBuild(); // build manager içindeki gameobject çaðrýlýyor.
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }
    private void OnMouseEnter() // node un üzerine geldiðimizde rengi deðþiyor.
    {
        if (buildmanager.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit() // üzerinden çýkýnca da rengi tekrardan eski halini alýyor.
    {
        rend.material.color = startColor;
    }
}
