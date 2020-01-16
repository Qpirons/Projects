using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(Random.Range(-1f, 1f), -5f);
        rigid.angularVelocity = Random.Range(-200, 200);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name
        Debug.Log("collision name = " + col.gameObject.tag);
        if (col.gameObject.tag == "Ship")
        {
            Destroy(col.gameObject);
        }
    }
}
