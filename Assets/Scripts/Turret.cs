using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    [Header("General")]

    public float range = 15f;

    [Header("Use Bullets(default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer Linerenderer;
    public ParticleSystem ImpactEffect;
    public Light ImpactLight;
    [Header("Unity Setup Fields")]
    public string enemytag = "enemy";

    public Transform PartToRotate;
    public float TurnSpeed = 10f;

    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach ( GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy<shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy&& shortestDistance<=range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    
    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (Linerenderer.enabled)
                {
                    Linerenderer.enabled = false;
                    ImpactEffect.Stop();
                    ImpactLight.enabled = false;
                }
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }

    }
    void Laser()
    {
        if (!Linerenderer.enabled)
        {
            Linerenderer.enabled = true;
            ImpactEffect.Play();
            ImpactLight.enabled = true;
        }
        Linerenderer.SetPosition(0, firePoint.position);
        Linerenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        ImpactEffect.transform.position = target.position + dir.normalized * .3f;

        ImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }
    private void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookdirection = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookdirection, Time.deltaTime * TurnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Shoot()
    {
        GameObject bulletgo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bllt = bulletgo.GetComponent<bullet>();
        if (bllt)
        {
            bllt.seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
