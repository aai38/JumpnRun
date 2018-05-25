using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesSpawner : MonoBehaviour {

    public GameObject collectables;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(30f, 805f);
            randY = Random.Range(335f, 55f);
            whereToSpawn = new Vector2(randX,randY);
            Instantiate(collectables, whereToSpawn, Quaternion.identity);
        }

    }
}
