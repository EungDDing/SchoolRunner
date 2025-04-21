using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stage : MonoBehaviour, IScroll
{
    [SerializeField] private float scrollSpeed = 0.0f;

    private ScrollManager scrollManager;

    private void Update()
    {
        Scroll();
    }
    
    public void InitStage()

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

    public void Scroll()
    {
        transform.position += -transform.forward * (scrollSpeed * Time.deltaTime);
    }
    public void StartMapControl()
    {
        StartCoroutine(MoveStartMap());
    }
    private IEnumerator MoveStartMap()
    {
        yield return new WaitForSeconds(3.0f);
        scrollSpeed = 20.0f;
    }
    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }
}
