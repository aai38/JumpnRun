using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		CollectablesText.coinAmount += 1;
		Destroy (gameObject);
	}
	
}
