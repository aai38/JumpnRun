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

    private bool jumpAllowed = false;
    private Vector2 startTouchPosition, endTouchPosition;
    private float jumpForce = 700f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        SwipeCheck();

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            moveright = false;
			moveleft = true;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            moveright = true;
            moveleft = false;

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
                b.GetComponent<Rigidbody2D>().AddForce(transform.right * 2000);
            } else {
                b.GetComponent<Rigidbody2D>().AddForce(-transform.right * 2000);
            }

                /*
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

*/

        }
    }

    private void SwipeCheck() {
        if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            endTouchPosition = Input.GetTouch(0).position;
            if(endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0) {
                jumpAllowed = true; 
            }
        }
    }

    private void FixedUpdate() {
        JumpIfAllowed();
    }

    private void JumpIfAllowed() {
        if (jumpAllowed) {
            rb.AddForce(Vector2.up * jumpForce);
            jumpAllowed = false;
        }
    }
}
