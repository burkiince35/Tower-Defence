using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emerge : MonoBehaviour
{
    public GameObject mergedObject;
    int ID;
    Transform Block1;
    Transform Block2;
    public float distance;
    public float mergespeed;
    bool canMerge;
    void Start()
    {
        ID = GetInstanceID();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cube"))
        {
            Block1 = transform;
            Block2 = collision.transform;
            canMerge = true;
            Destroy(collision.gameObject.GetComponent<Rigidbody>());
            Destroy(GetComponent<Rigidbody>());
        }
    }

    private void FixedUpdate()
    {
        MoveTowards();
    }
    public void MoveTowards()
    {
        if (canMerge)
        {
            transform.position = Vector3.MoveTowards(Block1.position, Block2.position, mergespeed);
            if (Vector3.Distance(Block1.position,Block2.position)<distance)
            {
                if (ID < Block2.gameObject.GetComponent<Emerge>().ID) { return; }
                Debug.Log($"Sending from {gameObject.name} with ID number: {ID}");
                GameObject o = Instantiate(mergedObject, transform.position, Quaternion.identity) as GameObject;
                Destroy(Block2.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
