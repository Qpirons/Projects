using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name
        Debug.Log("collision name = " + col.gameObject.tag);
        if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "Meteor")
        {
            Destroy(col.gameObject);
        }
    }
}
