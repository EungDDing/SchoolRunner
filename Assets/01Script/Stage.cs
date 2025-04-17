using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour, IScroll
{
    [SerializeField] private float scrollSpeed = 0.0f;

    private ScrollManager scrollManager;

    private void Update()
    {
        Scroll();
    }
    private void Start()
    {
        StartCoroutine(GetScrollManager());
    }
    private IEnumerator GetScrollManager()
    {
        while (scrollManager == null)
        {
            scrollManager = FindObjectOfType<ScrollManager>();
            yield return null;
        }

        scrollManager.AddScrollObject(this);
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
