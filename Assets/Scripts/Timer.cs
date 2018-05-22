using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour {

    private float timeLeft;
	// Use this for initialization
	void Start () {
        timeLeft = 180;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        TextMeshProUGUI mText = GameObject.FindWithTag("time").GetComponent<TextMeshProUGUI>();

        int timeToShow = (int) timeLeft;
        mText.SetText("time: " + timeToShow / 60 + ":" + timeToShow % 60);
        if (timeLeft < 0)
        {
            GameOver();
        }
	}

    private void GameOver() {
        TextMeshProUGUI mText = GameObject.FindWithTag("collectables").GetComponent<TextMeshProUGUI>();

        //PlayerPrefs.SetInt("highscore" , mText);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
        
}
