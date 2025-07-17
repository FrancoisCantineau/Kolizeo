using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{

    public static SceneTransitionManager Instance;
    public string[] transitionTriggers = { "Transition1", "Transition2", "Transition3" };
    public Animator transitionAnimator;
    public GameObject loadingBar;

    bool simulateLoading;
    private string pendingScene;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TransitionToScene(string sceneName)
    {
        pendingScene = sceneName;

        string trigger = transitionTriggers[Random.Range(0, transitionTriggers.Length)];
        transitionAnimator.SetTrigger(trigger);

        simulateLoading = Random.Range(0, 3) == 0;

    }
    
    public void OnFullyCovered()
    {
        if (simulateLoading == true)
        {
            loadingBar?.SetActive(true);

            transitionAnimator.speed = 0.0f;            
        }

        StartCoroutine(ContinueSceneLoading());

    }


    private IEnumerator ContinueSceneLoading()
    {
        float waitTime = simulateLoading ? 3f : 0f;
        float timer = 0f;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(pendingScene);
        asyncLoad.allowSceneActivation = false;

        while (timer < waitTime || asyncLoad.progress < .9f)
        {
            timer += Time.deltaTime;

            if (simulateLoading && loadingBar != null)
            {
                Slider slider = loadingBar.GetComponentInChildren<Slider>();
                if (slider)
                    slider.value = Mathf.Clamp01(timer / waitTime);
            }

            yield return null;
        
        }

        if (simulateLoading == true)
        {
            AudioManager.Instance.PlayTransitionOut();

            transitionAnimator.speed = 1.0f;
        }

       
        asyncLoad.allowSceneActivation = true;

        if (simulateLoading)
            loadingBar?.SetActive(false);
    }

}
