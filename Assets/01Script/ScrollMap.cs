using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMap : MonoBehaviour, IScroll
{
    [SerializeField] private float scrollSpeed = 0.0f;
    private float resetZ = 20.0f;
    private Vector3 resetPosition = new Vector3(0.0f, 0.0f, 20.0f);

    private ScrollManager scrollManager;

    private void Update()
    {
        Scroll();
    }
    private void OnEnable()
    {
        if (scrollManager == null)
        {
            scrollManager = FindObjectOfType<ScrollManager>();
        }

        if (scrollManager != null)
        {
            scrollManager.AddScrollObject(this);
        }
    }
    private void OnDisable()
    {
        if (scrollManager != null)
        {
            scrollManager.RemoveScrollObject(this);
        }
    }
    public void Scroll()
    {
        transform.position += -transform.forward * (scrollSpeed * Time.deltaTime);
    }

    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }
}
