using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

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
    public bool isKeyEnabled_shoot = true;
    public bool isKeyEnabled_jump = true;
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

    public GameObject timeover_text;


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


        //mySpriteRenderer.flipX = false;
        if(characterSelection == 2) {
            mySpriteRenderer.flipX = true;
        } else {
            mySpriteRenderer.flipX = false;
        }
		
        shootleft = true;
        shootright = false;
        shootAudio = gameObject.AddComponent<AudioSource>();
        shootAudio.clip = Resources.Load("shoot2") as AudioClip;
        jumpAudio = gameObject.AddComponent<AudioSource>();
        jumpAudio.clip = Resources.Load("jump") as AudioClip;
    }

    void OnBecameInvisible()
    {
        
        Destroy(gameObject);
        GameOver();
    }

    private void GameOver()
    {
        TextMeshProUGUI mText = GameObject.FindWithTag("collectables").GetComponent<TextMeshProUGUI>();

        timeover_text.SetActive(true);

        StartCoroutine(Freeze());

        //PlayerPrefs.SetInt("highscore" , mText);

    }



    void Update()
    {
        //SwipeCheck();
        if (gameObject != null)
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-movespeed, rb.velocity.y);
                shootleft = true;
                shootright = false;
                //moveright = false;
                //moveleft = true;

                //mySpriteRenderer.flipX = false;
                if (characterSelection == 2)
                {
                    mySpriteRenderer.flipX = true;
                }
                else
                {
                    mySpriteRenderer.flipX = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(movespeed, rb.velocity.y);
                shootleft = false;
                shootright = true;

                //mySpriteRenderer.flipX = true;
                if (characterSelection == 2)
                {
                    mySpriteRenderer.flipX = false;
                }
                else
                {
                    mySpriteRenderer.flipX = true;
                }

                //moveright = true;
                //moveleft = false;

            }

            if (Input.GetKeyDown(KeyCode.Space) && isKeyEnabled_shoot)
            {
                //GameObject b = (GameObject)(Instantiate(bullet, (Vector2)transform.position + transform.localScale.x * offset, Quaternion.identity));
                if (shootleft)
                {
                    //shoot = true;
                    GameObject b = (GameObject)(Instantiate(bullet, (Vector2)transform.position + transform.localScale.x * -offset, Quaternion.identity));
                    b.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed);
                    shootAudio.Play();
                    StartCoroutine(Freeze_Shoot());

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
                    StartCoroutine(Freeze_Shoot());
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && isKeyEnabled_jump)  //makes player jump
            {
                //moveup = true;
                jumpAudio.Play();
                rb.AddForce(jumpHeight, ForceMode2D.Impulse);
                StartCoroutine(Freeze_Jump());
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

            if (moveup && isKeyEnabled_jump)

            {
                jumpAudio.Play();
                rb.AddForce(jumpHeight, ForceMode2D.Impulse);
                StartCoroutine(Freeze_Jump());
            }

            if (shoot && isKeyEnabled_shoot)
            {

                if (moveleft || (!(moveleft && moveright) && mySpriteRenderer.flipX == false))
                {
                    GameObject b = (GameObject)(Instantiate(bullet, (Vector2)transform.position + transform.localScale.x * -offset, Quaternion.identity));
                    b.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed);
                    shootAudio.Play();
                    StartCoroutine(Freeze_Shoot());
                }
                else
                {
                    GameObject b = (GameObject)(Instantiate(bullet, (Vector2)transform.position + transform.localScale.x * offset, Quaternion.identity));
                    b.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
                    shootAudio.Play();
                    StartCoroutine(Freeze_Shoot());
                }
            }
        }
    }


    IEnumerator Freeze_Shoot()
    {
        isKeyEnabled_shoot = false;
        yield return new WaitForSeconds(0.8f);
        isKeyEnabled_shoot = true;
    }

    IEnumerator Freeze_Jump()
    {
        isKeyEnabled_jump = false;
        yield return new WaitForSeconds(0.8f);
        isKeyEnabled_jump = true;
    }

    IEnumerator Freeze()
    {

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Endscreen");

    }

       

}
