using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {

    public GameObject[] players;

	// Use this for initialization
	void Start () {
		int selected = PlayerPrefs.GetInt("selectedCharacter");
		Instantiate(players[selected], Vector2.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
