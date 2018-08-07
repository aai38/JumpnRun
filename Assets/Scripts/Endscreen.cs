using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Endscreen : MonoBehaviour {

    private static int highscore;
    private static int collectables;
    private int collectables_total;
    private static string level_played;
    private TextMeshProUGUI score_text;
    private TextMeshProUGUI collectables_text;
    private int maxCollectables;

    // Use this for initialization
    void Start () {
        
        level_played = PlayerPrefs.GetString("level_played");
        collectables_total = PlayerPrefs.GetInt("collectables_total" + level_played.ToLower());
        highscore = PlayerPrefs.GetInt("highscore_" + level_played.ToLower() + "inlevel");
        collectables = PlayerPrefs.GetInt("collectables_" + level_played.ToLower() + "inlevel");
        score_text = GameObject.FindWithTag("Highscore").GetComponent<TextMeshProUGUI>();
        score_text.SetText(highscore + "");
        collectables_text = GameObject.FindWithTag("collectables").GetComponent<TextMeshProUGUI>();
        maxCollectables = PlayerPrefs.GetInt("collectables_max" + level_played.ToLower());
        collectables_text.SetText(collectables + collectables_total + "/" + maxCollectables );

        PlayerPrefs.SetInt("collectables_total" + level_played.ToLower(), collectables + collectables_total);

    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
