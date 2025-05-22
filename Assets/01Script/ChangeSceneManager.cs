using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    public static ChangeSceneManager instance;

    [SerializeField] private Animator changeSceneAnimator;
    [SerializeField] private float changeTime = 4.4f;
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
    }

    public void StartSceneChange(string sceneName)
    {
        StartCoroutine(ChangeSceneCoroutine(sceneName));
    }
    private IEnumerator ChangeSceneCoroutine(string sceneName)
    {
        Debug.Log("ChangeSceneCoroutine 시작됨");

        changeSceneAnimator.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(changeTime);

        SceneManager.LoadScene(sceneName);

        yield return null;
        changeSceneAnimator.SetTrigger("End");
    }
}
