﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Endscreen : MonoBehaviour {

    private static int highscore;
    private static int collectables;
    private static string level_played;
    private TextMeshProUGUI score_text;
    private TextMeshProUGUI collectables_text;

    // Use this for initialization
    void Start () {
        level_played = PlayerPrefs.GetString("level_played");
        highscore = PlayerPrefs.GetInt("highscore_" + level_played.ToLower());
        collectables = PlayerPrefs.GetInt("collectables_" + level_played.ToLower());
        score_text = GameObject.FindWithTag("Highscore").GetComponent<TextMeshProUGUI>();
        score_text.SetText(highscore + "");
        collectables_text = GameObject.FindWithTag("collectables").GetComponent<TextMeshProUGUI>();
        collectables_text.SetText(collectables + "/15" );

    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
