using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 5f;
    public float LeftSide = -5.5f;
    public float RightSide = 5.5f;
    public GameObject Bullet;
    public Vector2 Fire;
    public float cooldown = 1f;
    private float timer = 1f;

    Rigidbody2D rigid;
    // Start is called before the first frame update

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(0.2f, -4.15f);

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        Fire = new Vector2(transform.position.x, transform.position.y + 1);
        if (Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(speed * -1, rigid.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2(speed, rigid.velocity.y);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            if (timer < cooldown)
            {
                Instantiate(Bullet, Fire, Quaternion.identity);
                timer = 1f;
            }
        }
    }
}
