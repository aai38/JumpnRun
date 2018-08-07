using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesSpawner : MonoBehaviour {

    public GameObject collectables;
    float randX;
    float randY;
    private int maxCollectables;
    private int collectablestotal;
    private string level_played;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public GameObject[] spawnPunkte;


    // Use this for initialization
    void Start () {
        level_played = PlayerPrefs.GetString("level_played");
        maxCollectables = PlayerPrefs.GetInt("collectables_max" + level_played.ToLower());

	}
	
	// Update is called once per frame
	void Update () {
        collectablestotal = PlayerPrefs.GetInt("collectables_total" + level_played.ToLower());
        if (Time.time > nextSpawn && maxCollectables >= collectablestotal)
        {
            
            nextSpawn = Time.time + spawnRate;
            //randX = Random.Range(30f, 805f);
            //randY = Random.Range(335f, 55f);

            int punkt = Random.Range(0, this.spawnPunkte.Length); //sucht ein zufälligen spawnpunkt raus
            Vector3 position = this.spawnPunkte[punkt].transform.position; //speichert die koordinaten des punktes
            //whereToSpawn = new Vector2(randX,randY);
            Instantiate(collectables, position, Quaternion.identity);
        }

    }
}
