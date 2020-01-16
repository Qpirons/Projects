using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public int damage = 50;
    public float speed = 70f;
    public GameObject impact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceperFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distanceperFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceperFrame, Space.World);
    }
    public void Seek(Transform _target)
    {
        target = _target;
    }
    void HitTarget()
    {
        GameObject particle = Instantiate(impact, transform.position, transform.rotation);
        Destroy(particle, 2);
        Damage(target);
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if(e != null)
        {
            e.TakeDamage(damage);
        }
    }
}
