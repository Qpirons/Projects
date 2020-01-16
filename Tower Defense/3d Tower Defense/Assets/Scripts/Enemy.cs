using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
     public float speed;
    private Transform target;
    private int wavepointIndex = 0;
    public float Health = 100;
    void Start()
    {
        speed = startSpeed;
        target = Waypoints.waypoints[0];
    }
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= .2f)
        {
            GetNextLocation();
        }

        speed = startSpeed;
    }
    void GetNextLocation()
    {
        if(wavepointIndex >= Waypoints.waypoints.Length -1)
        {
            EndGoal();
            return;
        }
        ++wavepointIndex;
        target = Waypoints.waypoints[wavepointIndex];
    }
    void EndGoal()
    {
        --PlayerStats.Lives;
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        if(Health <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }
    void Die()
    {
        Destroy(gameObject);
        PlayerStats.Money += 15;
    }
}
