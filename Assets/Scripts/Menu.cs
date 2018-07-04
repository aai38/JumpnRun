using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CharacterSelection() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }

    private void Start()
    {
        PlayerPrefs.SetInt("collectables_maxforest", 20);
        PlayerPrefs.SetInt("collectables_maxlava", 30);
        PlayerPrefs.SetInt("collectables_maxsky", 40);
    }

}
