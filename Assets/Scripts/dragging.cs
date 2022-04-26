using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragging : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    int ID;
    private void Start()
    {
        ID = GetInstanceID();
    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cube"))
        {
            if (ID<collision.gameObject.GetComponent<dragging>().ID)
            {
                return;
            }
            Debug.Log("çarptý");
        }
    }
}
