using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRect : MonoBehaviour {

    public RectTransform panel;
    public Button[] buttons;
    public Button selectButton;
    public Button purchaseButton;
    public RectTransform center;

    private float[] distance;
    private bool dragging = false;
    private int buttonDistance;
    private int minButtonNum;
    private Animation wiggle;
    private GameObject selectedCharacter;
    private bool targetNearestButton = true;

	// Use this for initialization
	void Start () {
        int buttonLength = buttons.Length;
        distance = new float[buttonLength];

        buttonDistance = (int)Mathf.Abs(buttons[1].GetComponent<RectTransform>().anchoredPosition.x - buttons[0].GetComponent<RectTransform>().anchoredPosition.x);
        //buttons.onClick.AddListener(TaskOnClick());

        purchaseButton.gameObject.SetActive(true);
        selectButton.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < buttons.Length; i++) {
            distance[i] = Mathf.Abs(center.transform.position.x - buttons[i].transform.position.x);
        }

        if (targetNearestButton)
        {
            float minDistance = Mathf.Min(distance);

            for (int a = 0; a < buttons.Length; a++)
            {
                if (minDistance == distance[a])
                {
                    minButtonNum = a;
                    //buttons[minButtonNum].name gives Name of the Button in center

                    wiggle = GameObject.Find("Player" + (minButtonNum + 1)).GetComponent<Animation>();
                    wiggle.Play("CharacterAnimationSelection");
                    SaveSelectedCharacter(minButtonNum);
                }
            }

            if (!dragging)
            {
                LerpToButton(minButtonNum * -buttonDistance);

            }


        }

        //TODO Jump to Character when clicked
		/*for (int b = 0; b < buttons.Length; b++)
		{
			minButtonNum = b;
			if (EventSystem.current.currentSelectedGameObject.name == ("Player" + (minButtonNum + 1)))
			{
                targetNearestButton = false;
                minButtonNum = b;
				wiggle = GameObject.Find("Player" + (minButtonNum + 1)).GetComponent<Animation>();
				wiggle.Play("CharacterAnimationSelection");
			}
		}*/
	}

    void LerpToButton(int position) {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 5f); //Number is force, lower for lighter scrollin

        //With this we dont need to wait till Button is in the center to be selected
        /*if (Mathf.Abs(position - newX) < 5f) {
            newX = position;
        }*/

        //Selects Button that is in Center
        if (Mathf.Abs(newX) >= Mathf.Abs(position) - 1f && Mathf.Abs(newX) <= Mathf.Abs(position) + 1) {
			//buttons[minButtonNum].Select();
			
		}

        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;

    }

    public void StartDrag() {
        dragging = true;
		purchaseButton.gameObject.SetActive(false);
		selectButton.gameObject.SetActive(false);
    }

    public void EndDrag () {
        dragging = false;
		purchaseButton.gameObject.SetActive(true);
		selectButton.gameObject.SetActive(true);
    }

    public void TaskOnClick(int buttonIndex) {
        targetNearestButton = false;
        minButtonNum = buttonIndex;
    }

    public void SaveSelectedCharacter(int number) {
        selectedCharacter = GameObject.Find("Player" + (number + 1)).GetComponent<GameObject>();
		
    }

    public void SelectOnClick () {

        if(minButtonNum == 6) {
            PlayerPrefs.SetInt("CharacterChoice", 11);
        } else {
            PlayerPrefs.SetInt("CharacterChoice", minButtonNum);
        }

        Debug.Log(minButtonNum);
    } 
}
