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

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

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


        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                }
                //swipe down

            }
        }
    }
}
