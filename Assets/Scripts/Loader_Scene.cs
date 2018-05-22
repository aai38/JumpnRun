using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Loader_Scene : MonoBehaviour {

    public GameObject loadingScrene;
    public Slider slider;
    //public GameObject text;

    public void Load (int sceneIndex) {
        StartCoroutine(LoadAsynchronously(sceneIndex));

        
    }

    IEnumerator LoadAsynchronously (int sceneIndex) {
        
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        loadingScrene.SetActive(true);


        while (operation.isDone == false) {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            TextMeshProUGUI mText = GameObject.FindWithTag("percentage").GetComponent<TextMeshProUGUI>();

            mText.SetText(progress * 100 + "%");
            yield return null;
        }

    } 
}
