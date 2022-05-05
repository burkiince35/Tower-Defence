using System;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    public float explosionRadios = 0f;
    public float speed = 70f;
    public GameObject impactEffect;
    public int damageAmount = 50;
    public void seek(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if (target==null)
        {
            Destroy(gameObject);
            return;
        }
        
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude<=distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 3f);
        if (explosionRadios>0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders =  Physics.OverlapSphere(transform.position, explosionRadios);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "enemy" )
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        enemy e = enemy.GetComponent<enemy>();
        if (e)
        {
            e.TakeDamage(damageAmount);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadios);
    }
}
