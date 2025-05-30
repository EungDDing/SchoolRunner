using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMode : MonoBehaviour
{
    private void Start()
    {
        // StartCoroutine(SetCanvasMode());
    }

    private IEnumerator SetCanvasMode()
    {
        while (Camera.main == null)
        {
            yield return null;
        }

        if (TryGetComponent<Canvas>(out Canvas canvas))
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = Camera.main;
            Debug.Log("Canvas에 카메라 연결 완료!");
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += ChangeScene;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ChangeScene;
    }
    private void ChangeScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        StartCoroutine(SetCanvasMode());
    }
}
