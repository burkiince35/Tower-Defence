using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emerge : MonoBehaviour
{
    public GameObject mergedObject;
    int ID;
    void Start()
    {
        ID = GetInstanceID();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cube"))
        {
            if (ID < collision.gameObject.GetComponent<Emerge>().ID)
            {
                return;
            }
            Debug.Log($"Sending from {gameObject.name} with ID number: {ID}");
            GameObject o = Instantiate(mergedObject, transform.position, Quaternion.identity) as GameObject;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
