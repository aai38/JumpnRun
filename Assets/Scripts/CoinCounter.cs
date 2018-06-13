using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour {

    private static int coinAmount = 0;
    public static int coinAmountTotal;
    TextMeshProUGUI mText;
    private AudioSource collectAudio;

    void Start()
    {
        
        mText = GameObject.FindWithTag("collectables").GetComponent<TextMeshProUGUI>();
        coinAmountTotal = PlayerPrefs.GetInt("collectables");
        
        collectAudio = gameObject.AddComponent<AudioSource>();
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
            Destroy(gameObject, collectAudio.clip.length);
            // Destroy(gameObject);

        }
        else if (name == "bullet(Clone)") {
            Destroy(gameObject);
            Destroy(col.gameObject);
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
