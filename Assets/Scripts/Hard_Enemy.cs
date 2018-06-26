﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hard_Enemy : MonoBehaviour
{


    public float speed;

    private Transform target;

    private health health;

    private int damage;


    public GameObject gameObject;

    public GameObject enemy;

    public GameObject bullet;

    private Animation animation;

    public Collider2D rb;

    private AudioSource hitAudio;

    private AudioSource hurtAudio;

    private Rigidbody2D rigid;

    public Vector2 jumpHeight;


    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(JumpLogic());

        damage = 0;
        target = GameObject.FindWithTag("Player").transform;

		
		


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (bullet = GameObject.FindWithTag("Bullet"))
        {
            hitAudio = bullet.AddComponent<AudioSource>();
            hitAudio.clip = Resources.Load("fire") as AudioClip;
        }



	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        // Name of the object that collided with the enemy
        var name = obj.gameObject.name;
        obj.isTrigger = true;

		enemy = GameObject.FindWithTag("enemy");
		hurtAudio = enemy.AddComponent<AudioSource>();
		hurtAudio.clip = Resources.Load("hit") as AudioClip;
		

        // If the enemy collided with a bullet
        if (name == "bullet(Clone)")
        {
            if (damage == 0)
            {
                damage += 1;
                Destroy(obj.gameObject);
            }
            // Destroy itself (the enemy) and the bullet
            else if (damage == 1)
            {

                hitAudio.Play();
                Destroy(obj.gameObject);
                Destroy(gameObject);
                //TODO Score-Methode aufrufen
                Score.scoreValue += 100;
            }
        }

        // If the enemy collided with the character
        if (name == "Character")
        {
            hurtAudio.Play();
            health = GameObject.FindWithTag("health_script").GetComponent<health>();
            Destroy(gameObject);
            health.DestroyHeart();
            GameObject.Find("Character").GetComponent<Animation>().Play("EnemyDie");
            // Destroy itself (the enemy) to keep things simple

        }
    }

    IEnumerator JumpLogic()
    {
        float minWaitTime = 5;
        float maxWaitTime = 10;

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            rigid.AddForce(jumpHeight, ForceMode2D.Impulse);
        }
    }
}


