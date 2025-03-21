﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Loading_beginning : MonoBehaviour
{

    public Slider slider;
    private AsyncOperation async;


    IEnumerator Start()

    {
        PlayerPrefs.SetInt("collectables_totalforest", 0);
        PlayerPrefs.SetInt("collectables_totallava", 14);
        PlayerPrefs.SetInt("collectables_totalsky", 0);
        yield return new WaitForSeconds(1f);
        async = SceneManager.LoadSceneAsync("menu");

    }

    void Update()

    {
        TextMeshProUGUI mText = GameObject.FindWithTag("percentage").GetComponent<TextMeshProUGUI>();

        float progress = Mathf.Clamp01(async.progress / 0.9f);
        mText.SetText(progress * 100 + "%");
        slider.value = progress;
    }
}