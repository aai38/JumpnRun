using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public static int scoreValue;
    private string level_played;
    private TextMeshProUGUI score;
    private int highscore;


    // Use this for initialization
    void Start()
    {
        level_played = PlayerPrefs.GetString("level_played");
        scoreValue = 0;
        score = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
        score.SetText("Score: " + scoreValue);
        highscore = PlayerPrefs.GetInt("highscore_" + level_played.ToLower());
       

    }

    // Update is called once per frame
    void Update()
    {
        score.SetText( "Score: " + scoreValue);
        PlayerPrefs.SetInt("highscore_" + level_played.ToLower() + "inlevel", scoreValue);
        if(scoreValue > highscore) {
            PlayerPrefs.SetInt("highscore_" + level_played.ToLower(), scoreValue);
        }
    }
}

