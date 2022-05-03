using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeObjectOnGrid : MonoBehaviour
{
    public Transform gridCellPrefab;
    public Transform Turret;
    public Transform onMousePrefab;

    public Vector3 smoothMousePosition;
   

    private Vector3 mousePosition;
    private node[,] nodes;
    private Plane plane;
    void Start()
    {
        
        plane = new Plane(Vector3.up, transform.position);
    }

    void Update()
    {
        GetMousePositionOnGrid();
    }
    void GetMousePositionOnGrid()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray,out var enter))
        {
            mousePosition = ray.GetPoint(enter);
            smoothMousePosition = mousePosition;
            mousePosition.y = 0;
            mousePosition = Vector3Int.RoundToInt(mousePosition);
            foreach (var node in nodes)
            {
                if (node.cellPosition==mousePosition && node.isPlaceable)
                {
                    if (Input.GetMouseButtonUp(0) && onMousePrefab)
                    {
                        node.isPlaceable = false;
                        onMousePrefab.GetComponent<objeFollowMouse>().isOnGrid = false;
                        onMousePrefab.position = node.cellPosition + new Vector3(0, 0.5f, 0);
                        onMousePrefab = null;
                    }
                }
            }
        }
    }

    public void OnMouseClickOnUI()
    {
        if (onMousePrefab==null)
        {
            onMousePrefab = Instantiate(Turret, mousePosition, Quaternion.identity);
        }
    }
    
}

public class node
{
    public bool isPlaceable;
    public Vector3 cellPosition;
    public Transform obje;

    public node(bool isPlaceable,Vector3 cellPosition, Transform obje)
    {
        this.isPlaceable = isPlaceable;
        this.cellPosition = cellPosition;
        this.obje = obje;
    }
}
