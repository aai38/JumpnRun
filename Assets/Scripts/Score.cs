using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public static int scoreValue;
    private TextMeshProUGUI score;
    private int highscore;


    // Use this for initialization
    void Start()
    {
        scoreValue = 0;
        score = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
        score.SetText("Score: " + scoreValue);
        highscore = PlayerPrefs.GetInt("highscore");

    }

    // Update is called once per frame
    void Update()
    {
        score.SetText( "Score: " + scoreValue);
        if(scoreValue > highscore) {
            PlayerPrefs.SetInt("highscore", scoreValue);
        }
    }
}

