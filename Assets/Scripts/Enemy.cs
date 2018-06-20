﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{


    public float speed;

    private Transform target;

    private health health;


    public GameObject gameObject;

    private Animation animation;

    public Collider2D rb;

    private AudioSource hitAudio;

    public GameObject bullet;


    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

        bullet = GameObject.FindWithTag("Bullet");
        hitAudio = bullet.AddComponent<AudioSource>();
        hitAudio.clip = Resources.Load("fire") as AudioClip;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D obj)
	{
		// Name of the object that collided with the enemy
		var name = obj.gameObject.name;
        obj.isTrigger = true;
    



        // If the enemy collided with a bullet
        if (name == "bullet(Clone)")
		{
            // Destroy itself (the enemy) and the bullet
            hitAudio.Play();

            Destroy(obj.gameObject);
            Destroy(gameObject);
            //TODO Score-Methode aufrufen
            Score.scoreValue += 50;
		}

		// If the enemy collided with the character
		if (name == "Character")
		{
           
            health = GameObject.FindWithTag("health_script").GetComponent<health>();
            Destroy(gameObject);
            health.DestroyHeart();
            GameObject.Find("Character").GetComponent<Animation>().Play("EnemyDie");
			// Destroy itself (the enemy) to keep things simple
			
		}
	}
}


