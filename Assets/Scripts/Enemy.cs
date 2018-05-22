using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{


    public float speed;

    private Transform target;

    private health health;


    public GameObject gameObject;

    public Collider2D rb;


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

    void OnTriggerEnter2D(Collider2D obj)
	{
		// Name of the object that collided with the enemy
		var name = obj.gameObject.name;
        obj.isTrigger = true;

        Debug.Log(name);

		// If the enemy collided with a bullet
		if (name == "bullet(Clone)")
		{
			// Destroy itself (the enemy) and the bullet
			Destroy(gameObject);
			Destroy(obj.gameObject);
            Debug.Log("hit enemy");
            //TODO Score-Methode aufrufen
		}

		// If the enemy collided with the character
		if (name == "Character")
		{
            Debug.Log("hit character");
            health = GameObject.FindWithTag("health_script").GetComponent<health>();
            health.DestroyHeart();
			// Destroy itself (the enemy) to keep things simple
			//TODO leben
		}
	}
}


