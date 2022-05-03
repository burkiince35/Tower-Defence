using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objeFollowMouse : MonoBehaviour
{
    private placeObjectOnGrid placeObjectOnGrid;
    public bool isOnGrid;
    void Start()
    {
        placeObjectOnGrid = FindObjectOfType<placeObjectOnGrid>();
    }

    
    void Update()
    {
        if (!isOnGrid)
        {
            transform.position = placeObjectOnGrid.smoothMousePosition + new Vector3(0, 0, 0);
        }
        
    }
}
