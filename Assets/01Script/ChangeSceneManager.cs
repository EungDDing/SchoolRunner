using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    public static ChangeSceneManager instance;

    [SerializeField] private Animator changeSceneAnimator;
    [SerializeField] private float changeTime = 4.0f;
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
        changeSceneAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(changeTime);

        SceneManager.LoadScene(sceneName);

        yield return null;
        changeSceneAnimator.SetTrigger("End");
    }
}
