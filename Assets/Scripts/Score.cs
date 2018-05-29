using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public static int scoreValue;
    private TextMeshProUGUI score;


    // Use this for initialization
    void Start()
    {
        scoreValue = 0;
        score = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
        score.SetText("Score: " + scoreValue);

    }

    // Update is called once per frame
    void Update()
    {
        score.SetText( "Score: " + scoreValue);
    }
}

