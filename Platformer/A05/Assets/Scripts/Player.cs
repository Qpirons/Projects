using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 5f;
    Rigidbody2D rigid;
    bool isGrounded;
    // Start is called before the first frame update

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = rigid.velocity = new Vector2(0, rigid.velocity.y);
        if (Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(speed * -1, rigid.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2(speed, rigid.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jump);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        else if(collision.gameObject.tag == "Enemy" && isGrounded == true)
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy" && isGrounded == false)
        {
            Destroy(collision.gameObject);
            GameManager.Scorevalue += 1;
        }
        else if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            GameManager.Scorevalue += 1;
        }
        else if (collision.gameObject.tag == "Door1")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (collision.gameObject.tag == "Door2")
        {
            SceneManager.LoadScene("Level3");
        }
        else if (collision.gameObject.tag == "Door3")
        {
            SceneManager.LoadScene("Victory");
        }
        else if (collision.gameObject.tag == "Death")
        {
            Destroy(this.gameObject);
        }
    }
}
