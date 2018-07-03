using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Values_Forest : MonoBehaviour {

	// Use this for initialization
    private static int highscore;
    private static int collectables;
    private static string level_played;
    private TextMeshProUGUI score_text;
    private TextMeshProUGUI collectables_text;

    // Use this for initialization
    void Start()
    {
        level_played = "Forest";
        PlayerPrefs.SetString("level_played", level_played);
        highscore = PlayerPrefs.GetInt("highscore_forest");
        collectables = PlayerPrefs.GetInt("collectables_totalforest");
        score_text = GameObject.FindWithTag("Highscore").GetComponent<TextMeshProUGUI>();
        score_text.SetText(highscore + "");
        collectables_text = GameObject.FindWithTag("collectables_highscore").GetComponent<TextMeshProUGUI>();
        collectables_text.SetText(collectables + "/15");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
