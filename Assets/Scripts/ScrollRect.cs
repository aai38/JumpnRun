using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRect : MonoBehaviour {

    public RectTransform panel;
    public Button[] buttons;
    public Button selectButton;
    public Button purchaseButton;
    private Button last;
    public RectTransform center;


    private float[] distance;
    private bool dragging = false;
    private int buttonDistance;
    private int minButtonNum;
    private int characterSelection;
    private Animation wiggle;
    private GameObject selectedCharacter;
    private GameObject lastCharacter;
    private bool targetNearestButton = true;
    private bool[] ispurchased = new bool[]{true, false, false, false, false, false};
    private TextMeshProUGUI coinText;
    private int coinAmountLava;
    private int coinAmountForest;
    private int coinAmountSky;
    private int coinAmountTotal;
    private int charactersPurchased;

    //just for testing
    private int coinTest = 20;

	// Use this for initialization
	void Start () {
        int buttonLength = buttons.Length;
        distance = new float[buttonLength];

        buttonDistance = (int)Mathf.Abs(buttons[1].GetComponent<RectTransform>().anchoredPosition.x - buttons[0].GetComponent<RectTransform>().anchoredPosition.x);

        purchaseButton.gameObject.SetActive(true);
        selectButton.gameObject.SetActive(true);

        coinText = GameObject.FindWithTag("collectables").GetComponent<TextMeshProUGUI>();
        coinAmountLava = PlayerPrefs.GetInt("collectables_totallava");
        coinAmountForest = PlayerPrefs.GetInt("collectables_totalforest");
        coinAmountSky = PlayerPrefs.GetInt("collectables_totalsky");
        coinAmountTotal = coinAmountLava + coinAmountForest + coinAmountSky;

        coinText.SetText("" + coinAmountTotal);

        purchaseButton.interactable = false;
        selectButton.interactable = false;

        ispurchased[0] = true;

        //For reseting Prefab
        //PlayerPrefs.SetInt("characters_purchased", 0);
        //PlayerPrefs.SetInt("CharacterChoice", 0);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(charactersPurchased);
        charactersPurchased = PlayerPrefs.GetInt("characters_purchased");
        for (int i = 1; i <= charactersPurchased; i++)
        {
            ispurchased[i] = true;
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            if (ispurchased[i] == false) {
                buttons[i].GetComponent<Image>().color = new Color(0, 0, 0, 0.8f);
            }
        }

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

                    //for Character Selection
                    characterSelection = PlayerPrefs.GetInt("CharacterChoice");
                    if(ispurchased[minButtonNum] == true) {
                        if(characterSelection == minButtonNum) {
                            selectButton.interactable = false;
                            selectButton.GetComponentInChildren<Text>().text = "SELECTED";
                        } else {
                            selectButton.interactable = true;
                            selectButton.GetComponentInChildren<Text>().text = "SELECT";
                        }
                    } else {
                        selectButton.interactable = false;
                        selectButton.GetComponentInChildren<Text>().text = "SELECT";
                    }

                    if(minButtonNum == a && ispurchased[a] == false) {
                        
                        if (coinAmountTotal /*coinTest*/ >= a*15)
                            {
                                purchaseButton.interactable = true;
                                selectButton.interactable = false;
                                purchaseButton.GetComponentInChildren<Text>().text = "PURCHASE";
                            }
                            else
                            {
                                selectButton.interactable = false;
                                purchaseButton.interactable = false;
                                purchaseButton.GetComponentInChildren<Text>().text = "COLLECT SOME MORE";
                            }

                    } else {
                        purchaseButton.GetComponentInChildren<Text>().text = "ALREADY OWNED";
                        purchaseButton.interactable = false;
                    }
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
        selectButton.interactable = false;
        selectButton.GetComponentInChildren<Text>().text = "SELECTED";
        PlayerPrefs.SetInt("CharacterChoice", minButtonNum);
    } 

    public void PurchaseOnClick () {
        selectButton.interactable = true;
        purchaseButton.interactable = false;
        purchaseButton.GetComponentInChildren<Text>().text = "ALREADY OWNED";
        buttons[minButtonNum].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        ispurchased[minButtonNum] = true;
        PlayerPrefs.SetInt("characters_purchased", charactersPurchased+1);
    } 
}
