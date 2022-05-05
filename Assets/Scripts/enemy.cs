using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 5f;
    private Transform target;
    private int wavepointIndex = 0;
    public int health = 100;
    public int moneyGain = 50;

    public GameObject deathEffect;
    private void Start()
    {
        target = waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);
        if (Vector3.Distance(transform.position, target.position)<=0.2f)
        {
            GetNextWayPoint();
        }
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.money += moneyGain;

        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);
        
        Destroy(gameObject);
    }

    private void GetNextWayPoint()
    {
        if (wavepointIndex >= waypoints.points.Length-1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
