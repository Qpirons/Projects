using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("Attributes")]
    public float turretRange = 15f;
    [Header("Use Bullet")]
    public GameObject bullet;
    public float fireRate = 1f;
    private float cooldown = 0f;


    [Header("Use Laser")]
    public bool usingLaser = false;
    public LineRenderer laserbeam;
    public ParticleSystem laserImpact;
    public int dps = 30;
    public float slowFactor = .5f;


    [Header("Setup")]
    public string enemytag = "Enemy";
    public Transform rotator;
    public float turnspeed = 10f;
    public Transform firepoint = null;
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeTarget", 0f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            if (usingLaser)
            {
                if (laserbeam.enabled)
                {
                    laserbeam.enabled = false;
                    laserImpact.Stop();
                }

                return;
            }
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotate = Quaternion.Lerp(rotator.rotation, lookRotation, Time.deltaTime* turnspeed).eulerAngles;
        rotator.rotation = Quaternion.Euler(0f, rotate.y, 0f);

        if (usingLaser)
        {
            laser();
        }
        else
        {
            if(cooldown <= 0f)
            {
                Shoot();
                cooldown = 1f / fireRate;
            }
        }
        cooldown -= Time.deltaTime;
    }

    void laser()
    {
        targetEnemy.TakeDamage(dps * Time.deltaTime);

        targetEnemy.Slow(slowFactor);

        if (!laserbeam.enabled)
        {
            laserbeam.enabled = true;
            laserImpact.Play();
        }
        laserbeam.SetPosition(0, firepoint.position);
        laserbeam.SetPosition(1, target.position);

        Vector3 direction = firepoint.position - target.position;

        laserImpact.transform.position = target.position + direction.normalized;
        laserImpact.transform.rotation = Quaternion.LookRotation(direction);
    }

   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }

    void ChangeTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(enemytag);
        float closest = Mathf.Infinity;
        GameObject closestTarget = null;
        foreach(GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if(distance < closest)
            {
                closest = distance;
                closestTarget = target;
            }
        }
        if(closestTarget != null && closest <= turretRange)
        {
            target = closestTarget.transform;
            targetEnemy = closestTarget.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
    void Shoot()
    {
        GameObject  bulletGO = Instantiate(bullet, firepoint.position, firepoint.rotation);
        Bullet bBullet = bulletGO.GetComponent<Bullet>();
        if(bBullet != null)
        {
            bBullet.Seek(target);
        }
    }
}
