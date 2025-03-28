﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	GameObject[] pauseObjects;
    Text playPause;
    public Button change;
    private AudioSource audioSource;

	// Use this for initialization
	void Start()
	{
        audioSource = GameObject.FindWithTag("sound").GetComponent<AudioSource>() ;
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
        playPause = change.GetComponentInChildren<Text>();
	}

	// Update is called once per frame
	void Update()
	{

		//uses the p button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
                audioSource.Pause();
				showPaused();
                playPause.text = "Play";
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				hidePaused();
                audioSource.Play();
                playPause.text = "Pause";
			}
		}
	}


	//Reloads the Level
	/*public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }*/

	//controls the pausing of the scene
	public void pauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
            audioSource.Pause();
            playPause.text = "Play";
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
            audioSource.Play();
            playPause.text = "Pause";
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	//loads inputted level
	/*public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }*/
}
