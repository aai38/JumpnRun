using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed;
    public bool moveright;
    public bool moveleft;
    public Vector2 jumpHeight;
    public GameObject bullet;
    public Vector2 offset = new Vector2(0.4f, 0.1f);
    public Vector2 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);

        }
        if (moveright)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }
        if (moveleft)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }
        if ( Input.GetKeyDown(KeyCode.UpArrow))  //makes player jump
        {

            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            GameObject b = (GameObject)(Instantiate(bullet, (Vector2)transform.position + transform.localScale.x * offset, Quaternion.identity));
            if (moveleft)
            {
                //b.GetComponent<Rigidbody2D>().AddForce(transform.right * 2000 * (-1));
            } else {
                //b.GetComponent<Rigidbody2D>().AddForce(transform.right * 2000);
            }
        }
    }
}
