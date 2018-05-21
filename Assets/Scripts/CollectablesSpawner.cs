using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesSpawner : MonoBehaviour {

    public GameObject collectables;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 5f;
    float nextSpawn = 0.0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(609f, 242f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(collectables, whereToSpawn, Quaternion.identity);
        }

    }
}
