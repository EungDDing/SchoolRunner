using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    public static ChangeSceneManager instance;

    [SerializeField] private Animator changeSceneAnimator;
    [SerializeField] private float changeTime = 4.4f;

    private bool isChange;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        isChange = false;
    }

    public void StartSceneChange(string sceneName)
    {
        if (isChange == false)
        {
            StartCoroutine(ChangeSceneCoroutine(sceneName));
        }   
    }
    private IEnumerator ChangeSceneCoroutine(string sceneName)
    {
        isChange = true;

        if (sceneName != "EndingScene")
        {
            Debug.Log("ChangeSceneCoroutine 시작됨");

            changeSceneAnimator.SetTrigger("Start");

            yield return new WaitForSecondsRealtime(changeTime);

            SceneManager.LoadScene(sceneName);

            yield return null;
            changeSceneAnimator.SetTrigger("End");

        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }

        isChange = false;
    }
}
