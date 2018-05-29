using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour {

    private int health_count;
    public GameObject heart_0;
    public GameObject heart_1;
    public GameObject heart_2;
    public GameObject died_text;


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
            Debug.Log(health_count);
            health_count--;
            heart_0.SetActive(false);



           
            died_text.SetActive(true);



            StartCoroutine(Freeze());

           
        }
        else if (health_count == 2)
        {
            Debug.Log(health_count);
            health_count--;
            heart_1.SetActive(false);

        } else if (health_count == 3) {
            Debug.Log(health_count);

            heart_2.SetActive(false);
            health_count--;
        }
    }

    IEnumerator Freeze()
    {
        
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
