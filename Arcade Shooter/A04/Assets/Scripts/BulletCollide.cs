using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name
        if (col.gameObject.tag == "Meteor")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            GameManager.Scorevalue += 1;
        }
    }
}
