using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Values_Lava : MonoBehaviour
{

    // Use this for initialization
    private static int highscore;
    private static int collectables;
    private static string level_played;
    private int maxCollectables;
    private TextMeshProUGUI score_text;
    private TextMeshProUGUI collectables_text;

    // Use this for initialization
    void Start()
    {
        level_played = "Lava";
        PlayerPrefs.SetString("level_played", level_played);
        highscore = PlayerPrefs.GetInt("highscore_lava");
        collectables = PlayerPrefs.GetInt("collectables_totallava");
        maxCollectables = PlayerPrefs.GetInt("collectables_maxlava");
        score_text = GameObject.FindWithTag("Highscore").GetComponent<TextMeshProUGUI>();
        score_text.SetText(highscore + "");
        collectables_text = GameObject.FindWithTag("collectables_highscore").GetComponent<TextMeshProUGUI>();
        collectables_text.SetText(collectables + "/" + maxCollectables);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
