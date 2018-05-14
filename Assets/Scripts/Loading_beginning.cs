using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_beginning : MonoBehaviour
{

    public Slider slider;
    private AsyncOperation async;

    IEnumerator Start()

    {
        yield return new WaitForSeconds(1f);
        async = SceneManager.LoadSceneAsync("menu");
    }

    void Update()

    {

        float progress = Mathf.Clamp01(async.progress / 0.9f);
        slider.value = progress;
    }
}