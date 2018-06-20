using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Sound : MonoBehaviour {
    private AudioSource press;
	// Use this for initialization
	

    public void PressButton () {
        press = gameObject.AddComponent<AudioSource>();
        press.clip = Resources.Load("pressbutton") as AudioClip;
    }
}
