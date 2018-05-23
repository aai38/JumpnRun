using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed;
    public float turnSpeed;
    public bool moveright;
    public bool moveleft;
    public bool shootleft;
    public bool shootright;
    public bool shoot;
    public bool moveup;
    public bool isKeyEnabled = true;
    public Vector2 jumpHeight;
    public GameObject bullet;
    public Vector2 offset = new Vector2(0.4f, 0.1f);
    public Vector2 velocity;
    private SpriteRenderer mySpriteRenderer;
    public int bulletSpeed = 5500;



    private bool jumpAllowed = false;
    private Vector2 startTouchPosition, endTouchPosition;
    private float jumpForce = 700f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.flipX = false;

    }

    void Update()
    {
        //SwipeCheck();

        //TODO nicht die ganze zeit in eine Richtung -> Taste nicht mehr gedrückt

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            shootleft = true;
            shootright = false;
            //moveright = false;
            //moveleft = true;
            mySpriteRenderer.flipX = false;

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            shootleft = false;
            shootright = true;
            mySpriteRenderer.flipX = true;
            //moveright = true;
            //moveleft = false;

        }

        if (Input.GetKeyDown(KeyCode.Space) && isKeyEnabled)
        {
            GameObject b = (GameObject)(Instantiate(bullet, (Vector2)transform.position + transform.localScale.x * offset, Quaternion.identity));
            if (shootleft)
            {
                //shoot = true;

                b.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed);
                Vector3 newScale = b.transform.localScale;
                newScale.x *= -1;
                b.transform.localScale = newScale;
                //TODO offset
                //b.transform.position = (Vector2)transform.position + transform.localScale.x * -offset;

                StartCoroutine(Freeze());

            }
            else
            {
                //shoot = true;
                b.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
                StartCoroutine(Freeze());
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isKeyEnabled)  //makes player jump
        {
            //moveup = true;
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
            StartCoroutine(Freeze());
        }

        if (moveright)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            mySpriteRenderer.flipX = true;
        }
        if (moveleft)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            mySpriteRenderer.flipX = false;
        }

        if (moveup && isKeyEnabled)
        {
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
            StartCoroutine(Freeze());
        }

        if (shoot && isKeyEnabled)
        {
            GameObject b = (GameObject)(Instantiate(bullet, (Vector2)transform.position + transform.localScale.x * offset, Quaternion.identity));
            if (moveleft || (!(moveleft && moveright) && mySpriteRenderer.flipX == false))
            {
                b.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed);
                StartCoroutine(Freeze());
            }
            else
            {
                b.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
                StartCoroutine(Freeze());
            }
        }
    }


    IEnumerator Freeze()
    {
        isKeyEnabled = false;
        yield return new WaitForSeconds(0.8f);
        isKeyEnabled = true;
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

        
    

   /* private void SwipeCheck() {
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
    }*/
}
