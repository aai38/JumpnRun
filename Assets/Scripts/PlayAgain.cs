using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {

    private static string level_played;

    void Start() {
        level_played = PlayerPrefs.GetString("level_played");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(level_played);
    }
}
