using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    [Header("optional")]
    private Renderer rend;
    private Color startColor;

    public GameObject turret;
    
    BuildManager buildmanager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildmanager = BuildManager.instance;
    }

    private void OnMouseDown() // node a basýnca turret spawnlýyor.
    {
        if (!buildmanager.CanBuild) // herhangi turret butonuna basýlmadýysa node a basýnca biþi olmayacak.
        {
            return;
        }
        if (turret!=null)
        {
            return;
        }
        buildmanager.BuildTurretOn(this);
    }
    private void OnMouseEnter() // node un üzerine geldiðimizde rengi deðþiyor.
    {
        if (!buildmanager.CanBuild)
        {
            return;
        }
        rend.material.color = hoverColor;
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
