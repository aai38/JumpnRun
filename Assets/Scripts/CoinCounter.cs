using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour {

    private int coinAmount;

    void Start()
    {
        coinAmount = 0;
    }

	void OnTriggerEnter2D(Collider2D col)
	{
        TextMeshProUGUI mText = GameObject.FindWithTag("collectables").GetComponent<TextMeshProUGUI>();
        coinAmount += 1;
        mText.SetText("" + coinAmount);
		
		Destroy (gameObject);
	}
	
}
