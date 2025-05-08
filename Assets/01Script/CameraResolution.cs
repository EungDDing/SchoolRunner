using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    private void Awake()
    {
        if (TryGetComponent<Camera>(out Camera cam))
        {
            Rect viewportRect = cam.rect;
            float scaleHeight = ((float)Screen.width / Screen.height) / ((float)9 / 16);
            float scaleWidth = 1.0f / scaleHeight;

            if (scaleHeight < 1.0f)
            {
                viewportRect.height = scaleHeight;
                viewportRect.y = (1.0f - scaleHeight) / 2.0f;
            }
            else
            {
                viewportRect.width = scaleWidth;
                viewportRect.x = (1.0f - scaleWidth) / 2.0f;
            }
            cam.rect = viewportRect;
        }
    }
}
