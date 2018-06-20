using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour {

    private static int coinAmount = 0;
    public static int coinAmountTotal;
    TextMeshProUGUI mText;
    private AudioSource collectAudio;
    private GameObject player;

    void Start()
    {
        
        mText = GameObject.FindWithTag("collectables").GetComponent<TextMeshProUGUI>();
        coinAmountTotal = PlayerPrefs.GetInt("collectables");


        player = GameObject.FindWithTag("Player");
        collectAudio = player.AddComponent<AudioSource>();
        collectAudio.clip = Resources.Load("collect") as AudioClip;


    }

	void OnTriggerEnter2D(Collider2D col)
	{
        var name = col.gameObject.name;


        if(name == "Character") {
            collectAudio.Play();
            coinAmount += 1;
            mText.SetText("" + coinAmount);

            //noch buggy!
            
            Destroy(gameObject);

        }
        else if (name == "bullet(Clone)") {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else {
            
        }
		
	}

    private void Update()
    {
        mText.SetText("" + coinAmount);
        if(coinAmount > 0) {
            PlayerPrefs.SetInt("collectables", coinAmount + coinAmountTotal);
        }
    }

}
