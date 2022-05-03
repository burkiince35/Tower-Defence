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

    private void OnMouseDown() // node a bas�nca turret spawnl�yor.
    {
        if (buildmanager.GetTurretToBuild()==null) // herhangi turret butonuna bas�lmad�ysa node a bas�nca bi�i olmayacak.
        {
            return;
        }
        if (turret!=null)
        {
            return;
        }
        GameObject turretToBuild = buildmanager.GetTurretToBuild(); // build manager i�indeki gameobject �a�r�l�yor.
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }
    private void OnMouseEnter() // node un �zerine geldi�imizde rengi de��iyor.
    {
        if (buildmanager.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit() // �zerinden ��k�nca da rengi tekrardan eski halini al�yor.
    {
        rend.material.color = startColor;
    }
}
