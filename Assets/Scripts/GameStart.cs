using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

    /*public GameObject go;

	// Use this for initialization
	void Start () {
		go = GameObject.FindGameObjectWithTag("game_start");



        //StartCoroutine(ShowAtBeginning());


	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(ShowMessage());
	}

	IEnumerator ShowMessage()
	{
        go.SetActive(true);
		yield return new WaitForSeconds(3);
        go.SetActive(false);
	}*/

    public Text message;
	void Start()
	{
		Invoke("DisableText", 3f);//invoke after 5 seconds
	}
	void DisableText()
	{
		message.enabled = false;
	}
}
