using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour {

    private static int coinAmount = 0;
    TextMeshProUGUI mText;

    void Start()
    {
        
        mText = GameObject.FindWithTag("collectables").GetComponent<TextMeshProUGUI>();
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
    }

}
