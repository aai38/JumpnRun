using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRect : MonoBehaviour {

    public RectTransform panel;
    public Button[] buttons;
    public RectTransform center;

    private float[] distance;
    private bool dragging = false;
    private int buttonDistance;
    private int minButtonNum;

	// Use this for initialization
	void Start () {
        int buttonLength = buttons.Length;
        distance = new float[buttonLength];

        buttonDistance = (int)Mathf.Abs(buttons[1].GetComponent<RectTransform>().anchoredPosition.x - buttons[0].GetComponent<RectTransform>().anchoredPosition.x);
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < buttons.Length; i++) {
            distance[i] = Mathf.Abs(center.transform.position.x - buttons[i].transform.position.x);
        }

        float minDistance = Mathf.Min(distance);

        for (int a = 0; a < buttons.Length; a++) {
            if(minDistance == distance[a]) {
                minButtonNum = a;
            }
        }

        if(!dragging) {
            LerpToButton(minButtonNum * -buttonDistance);
        }
	}

    void LerpToButton(int position) {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 5f); //Number is force, lower for lighter scrollin
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag() {
        dragging = true;
    }

    public void EndDrag () {
        dragging = false;
    }
}
