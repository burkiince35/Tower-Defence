using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draganddrop : MonoBehaviour
{
    private GameObject selectedGameObject;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedGameObject == null)
            {
                RaycastHit hit = CastRay();
                if (hit.collider)
                {
                    if (!hit.collider.CompareTag("drag"))
                    {
                        return;
                    }
                    selectedGameObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            else
            {

            }
        }

        if (selectedGameObject)
        {
            Vector3 Position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedGameObject.transform.position).z);
            Vector3 worldPodition = Camera.main.ScreenToWorldPoint(Position);
            selectedGameObject.transform.position = new Vector3(worldPodition.x, .25f, worldPodition.z);
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar =
            new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear =
            new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 worldMousePosFar =
        Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear =
        Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
