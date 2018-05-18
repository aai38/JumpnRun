using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health  {

    private int health_count;
    public GameObject heart_0;
    public GameObject heart_1;
    public GameObject heart_2;


	// Use this for initialization
	void Start () {
        health_count = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyHeart () {
        if (health_count == 1)
        {
            health_count--;
            heart_0.SetActive(false);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (health_count == 2)
        {
            health_count--;
            heart_1.SetActive(false);

        } else if (health_count == 3) {
            health_count--;
            heart_2.SetActive(false);
        }
    }
}
