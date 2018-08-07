using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 3f;
    float nextSpawn = 0.0f;
    public GameObject[] spawnPunkte;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            int punkt = Random.Range(0, this.spawnPunkte.Length); //sucht ein zufälligen spawnpunkt raus
            Vector3 position = this.spawnPunkte[punkt].transform.position; //speichert die koordinaten des punktes
            Instantiate(enemy, position, Quaternion.identity);
        }
	}
}
