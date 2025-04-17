using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour, IScroll
{
    [SerializeField] private float scrollSpeed = 0.0f;
    private bool isScroll = false;

    private void Update()
    {
        Scroll();
    }
    private void OnEnable()
    {
        SetScrollSpeed(20.0f);
        SetEnableScroll(true);
    }
    private void OnDisable()
    {
        SetEnableScroll(false);
    }
    public void Scroll()
    {
        if (isScroll)
        {
            transform.position += -transform.forward * (scrollSpeed * Time.deltaTime);
        }
    }

    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }

    public void SetEnableScroll(bool isEnable)
    {
        isScroll = isEnable;
    }
}
