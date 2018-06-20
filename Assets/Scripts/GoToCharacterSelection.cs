using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCharacterSelection : MonoBehaviour {

	// Use this for initialization
    public void LoadLevel()
    {
        SceneManager.LoadScene("Character_Selection");
    }
}
