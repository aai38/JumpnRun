using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour {

    private static int coinAmount = 0;
    public static int coinAmountTotal;
    TextMeshProUGUI mText;

    void Start()
    {
        
        mText = GameObject.FindWithTag("collectables").GetComponent<TextMeshProUGUI>();
        coinAmountTotal = PlayerPrefs.GetInt("collectables");
    }

	void OnTriggerEnter2D(Collider2D col)
	{
        var name = col.gameObject.name;


        if(name == "Character") {
            coinAmount += 1;
            mText.SetText("" + coinAmount);
            Destroy(gameObject);
        } else if (name == "bullet(Clone)") {
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
