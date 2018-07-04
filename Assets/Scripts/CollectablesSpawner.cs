using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesSpawner : MonoBehaviour {

    public GameObject collectables;
    float randX;
    float randY;
    private int maxCollectables;
    private int collectablesInLevel;
    private string level_played;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;


    // Use this for initialization
    void Start () {
        level_played = PlayerPrefs.GetString("level_played");
        maxCollectables = PlayerPrefs.GetInt("collectables_max" + level_played.ToLower());

	}
	
	// Update is called once per frame
	void Update () {
        collectablesInLevel = PlayerPrefs.GetInt("collectables_" + level_played.ToLower() + "inlevel");
        if (Time.time > nextSpawn && maxCollectables >= collectablesInLevel)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(30f, 805f);
            randY = Random.Range(335f, 55f);
            whereToSpawn = new Vector2(randX,randY);
            Instantiate(collectables, whereToSpawn, Quaternion.identity);
        }

    }
}
