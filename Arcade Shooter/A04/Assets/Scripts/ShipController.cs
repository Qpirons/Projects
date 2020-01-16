using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 5f;
    public float LeftSide = -5.5f;
    public float RightSide = 5.5f;
    public GameObject Bullet;
    public Vector2 Fire;
    float cooldown = 1f;
    private float nextshot = 0;
    Rigidbody2D rigid;
    // Start is called before the first frame update

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(0f, -4.5f);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Fire = new Vector2(transform.position.x, transform.position.y + 1);
        if (Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(speed * -1, rigid.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2(speed, rigid.velocity.y);
        }
        if(Input.GetKey(KeyCode.Space) && Time.time > nextshot)
        {
            nextshot = Time.time + cooldown;
            Instantiate(Bullet, Fire, Quaternion.identity);
        }
    }
}
