using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{


    public float speed;

    private Transform target;


    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    /*void OnTriggerEnter2D(GameObject obj)
	{
		// Name of the object that collided with the enemy
		var name = obj.gameObject.name;

		// If the enemy collided with a bullet
		if (name == "bullet(Clone)")
		{
			// Destroy itself (the enemy) and the bullet
			Destroy(gameObject);
			Destroy(obj.gameObject);
		}

		// If the enemy collided with the spaceship
		if (name == "Character")
		{
			// Destroy itself (the enemy) to keep things simple
			Destroy(gameObject);
		}
	}*/
}


