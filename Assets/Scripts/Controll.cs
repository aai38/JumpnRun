﻿using System.Collections;
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
    public Vector2 offset = new Vector2();
    public Vector2 velocity;
    private SpriteRenderer mySpriteRenderer;
    public int bulletSpeed = 5500;
    private AudioSource shootAudio;
    private AudioSource jumpAudio;

    private string name;
    private int characterSelection;
    private Sprite characterSprite;
    private Sprite[] sprites;


    private bool jumpAllowed = false;
    private Vector2 startTouchPosition, endTouchPosition;
    private float jumpForce = 700f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        //TODO
        characterSelection = PlayerPrefs.GetInt("CharacterChoice");
        //name = "monsters_test_" + characterSelection;
        sprites = Resources.LoadAll<Sprite>("monsters_test");
        mySpriteRenderer.sprite = sprites[characterSelection];
        Debug.Log(characterSelection);

        if(characterSelection != 2) {
            mySpriteRenderer.flipX = false;
		} else {
			mySpriteRenderer.flipX = true;
		}

        shootleft = true;
        shootright = false;
        shootAudio = gameObject.AddComponent<AudioSource>();
        shootAudio.clip = Resources.Load("shoot2") as AudioClip;
        jumpAudio = gameObject.AddComponent<AudioSource>();
        jumpAudio.clip = Resources.Load("jump") as AudioClip;
    }



    void Update()
    {
        //SwipeCheck();


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            shootleft = true;
            shootright = false;
			//moveright = false;
			//moveleft = true;
			if (characterSelection != 2)
			{
				mySpriteRenderer.flipX = false;
			}
			else
			{
				mySpriteRenderer.flipX = true;
			}


        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            shootleft = false;
            shootright = true;
			if (characterSelection != 2)
			{
				mySpriteRenderer.flipX = false;
            } else {
                mySpriteRenderer.flipX = true;
            }
            //moveright = true;
            //moveleft = false;

        }

        if (Input.GetKeyDown(KeyCode.Space) && isKeyEnabled)
        {
            //GameObject b = (GameObject)(Instantiate(bullet, (Vector2)transform.position + transform.localScale.x * offset, Quaternion.identity));
            if (shootleft)
            {
                //shoot = true;
                GameObject b = (GameObject)(Instantiate(bullet, (Vector2)transform.position + transform.localScale.x * -offset, Quaternion.identity));
                b.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed);
                shootAudio.Play();
                StartCoroutine(Freeze());

            }
            else
            {
                //shoot = true;
                GameObject b = (GameObject)(Instantiate(bullet, (Vector2)transform.position + transform.localScale.x * offset, Quaternion.identity));
                shootAudio.Play();
				//offset:
				//b.transform.position = (Vector2)transform.position + transform.localScale.x * -offset;
				/*Vector3 newScale = b.transform.localScale;
				newScale.y *= -1;
				b.transform.localScale = newScale;*/

				b.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
                StartCoroutine(Freeze());
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isKeyEnabled)  //makes player jump
        {
            //moveup = true;
            jumpAudio.Play();
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
            StartCoroutine(Freeze());
        }

        if (moveright)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
			if (characterSelection != 2)
			{
				mySpriteRenderer.flipX = true;
            } else {
                mySpriteRenderer.flipX = false;
            }

        }
        if (moveleft)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
			if (characterSelection != 2)
			{
                mySpriteRenderer.flipX = false;
			}
			else
			{
				mySpriteRenderer.flipX = true;
			}

        }

        if (moveup && isKeyEnabled)
        
        {
            jumpAudio.Play();
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
            StartCoroutine(Freeze());
        }

        if (shoot && isKeyEnabled)
        {
            
            if (moveleft || (!(moveleft && moveright) && mySpriteRenderer.flipX == false))
            {
                GameObject b = (GameObject)(Instantiate(bullet, (Vector2)transform.position + transform.localScale.x * -offset, Quaternion.identity));
                b.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed);
                shootAudio.Play();
                StartCoroutine(Freeze());
            }
            else
            {
                GameObject b = (GameObject)(Instantiate(bullet, (Vector2)transform.position + transform.localScale.x * offset, Quaternion.identity));
                b.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
                shootAudio.Play();
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

       

}
