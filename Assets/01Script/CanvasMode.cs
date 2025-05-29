using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMode : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SetCanvasMode());
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
}
