using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    
    
    BuildManager buildmanager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildmanager = BuildManager.instance;
    }

    private void OnMouseDown() // node a bas�nca turret spawnl�yor.
    {
        if (!buildmanager.CanBuild) // herhangi turret butonuna bas�lmad�ysa node a bas�nca bi�i olmayacak.
        {
            return;
        }
        if (turret!=null)
        {
            return;
        }
        buildmanager.BuildTurretOn(this);
    }
    private void OnMouseEnter() // node un �zerine geldi�imizde rengi de��iyor.
    {
        if (!buildmanager.CanBuild)
        {
            return;
        }
        if (buildmanager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    private void OnMouseExit() // �zerinden ��k�nca da rengi tekrardan eski halini al�yor.
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
